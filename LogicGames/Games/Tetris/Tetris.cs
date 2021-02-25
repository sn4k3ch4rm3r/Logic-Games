using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogicGames.Games.Tetris
{
    public partial class Tetris : GameView
    {
        private Stopwatch timer = new Stopwatch();
        private TimeSpan lastMoveTime = new TimeSpan(0);
        private float tickTime = 0.5f;

        private Board board;
        private Tetrimino currentShape;

        private int score = 0;

        public Tetris() : base()
        {
            this.Text = "Tetris";

            DoubleBuffered = true;
            this.KeyDown += OnKeyDown;

            board = new Board(10, 20, base.container);
            currentShape = new Tetrimino(board, Shapes.Random());

            timer.Start();
        }

        private void MoveDown()
        {
            if (!currentShape.Move(0))
            {
                if(currentShape.Location.Y >= 0)
                    board.SetBlocks(currentShape.BlocksInBoard);
                
                int linesCleared = board.Clear();
                if(linesCleared > 0)
                    score += (int)Math.Pow(2, linesCleared - 1) * 100;

                if (!currentShape.Moved || currentShape.Location.Y < 0)
                {
                    board = new Board(10, 20, base.container);
                    score = 0;
                }
                currentShape = new Tetrimino(board, Shapes.Random());
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                MoveDown();
                score += 2;
            }
            else if(e.KeyCode == Keys.Left)
            {
                currentShape.Move(-1);
            }
            else if (e.KeyCode == Keys.Right)
            {
                currentShape.Move(1);
            }
            else if (e.KeyCode == Keys.Up)
            {
                currentShape.Rotate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.Blue), base.container);
            g.TranslateTransform(base.container.X, base.container.Y);

            TimeSpan timePassed = timer.Elapsed - lastMoveTime;
            if(timePassed.TotalSeconds >= tickTime)
            {
                MoveDown();
                score++;
                lastMoveTime = timer.Elapsed;
            }

            board.Render(g);
            currentShape.Render(g);

            g.DrawString($"Score: {score}", new Font("Arial", 15), new SolidBrush(Color.Black), (int)(base.container.Width * (2.0 / 3)) + 10, 30);

            Invalidate();
        }
    }
}

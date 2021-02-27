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
        private Tetrimino nextShape;

        private int score = 0;
        private int lines = 0;

        private bool gameOver = false;

        public Tetris() : base()
        {
            this.Text = "Tetris";

            DoubleBuffered = true;
            this.KeyDown += OnKeyDown;

            board = new Board(10, 20, base.container);
            nextShape = new Tetrimino(board, Shapes.Random());
            NextShape();

            timer.Start();
        }

        private void NextShape()
        {
            currentShape = nextShape;
            currentShape.MakeCurrent();
            nextShape = new Tetrimino(board, Shapes.Random());
        }

        private void MoveDown()
        {
            if (!currentShape.Move(0))
            {
                if(currentShape.Location.Y >= 0)
                    board.SetBlocks(currentShape.BlocksInBoard);
                
                int linesCleared = board.Clear();
                if (linesCleared > 0)
                {
                    score += (int)Math.Pow(2, linesCleared - 1) * 100;
                    lines += linesCleared;
                }

                if (!currentShape.Moved || currentShape.Location.Y < 0)
                    GameOver();
                NextShape();
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

        private void GameOver()
        {
            gameOver = true;
            Menus.GameMenu gameOverMenu = new Menus.GameMenu("Új játék", "Kilépés");
            base.ShowMenu(gameOverMenu);
        }

        protected override void MenuSelected(int selected)
        {
            switch(selected)
            {
                case 0:
                    board = new Board(10, 20, base.container);
                    nextShape = new Tetrimino(board, Shapes.Random());
                    NextShape();
                    score = 0;
                    lines = 0;
                    gameOver = false;
                    break;
                default:
                    this.Close();
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.TranslateTransform(base.container.X, base.container.Y);

            TimeSpan timePassed = timer.Elapsed - lastMoveTime;
            if (timePassed.TotalSeconds >= tickTime)
            {
                MoveDown();
                score++;
                lastMoveTime = timer.Elapsed;
            }

            board.Render(g);
            currentShape.Render(g);
            nextShape.Render(g);

            Font font = new Font("Arial", 15);
            SolidBrush textBrush = new SolidBrush(Resources.Colors.PrimaryText);
            SizeF stringSize = g.MeasureString("Következő:", font);
            int beginText = board.NextDisplayRect.Left - 3;

            g.DrawString("Következő:", font, textBrush, beginText, board.NextDisplayRect.Top - stringSize.Height);
            g.DrawString($"Pontszám: {score}\nSorok: {lines}", font, textBrush, beginText, 30);
            if(!gameOver) { 
                Invalidate();
            }
        }
    }
}

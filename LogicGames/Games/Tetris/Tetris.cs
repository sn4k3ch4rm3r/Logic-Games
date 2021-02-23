using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGames.Games.Tetris
{
    public partial class Tetris : GameView
    {
        private int boardWidth = 10;
        private int boardHeight = 20;
        private int blocksize;
        private Tetrimino test;
        public Tetris() : base()
        {
            this.Text = "Tetris";

            DoubleBuffered = true;
            this.KeyDown += OnKeyDown;

            blocksize = (int)((double)base.container.Height / boardHeight);
            test = new Tetrimino(blocksize, Shapes.Random());
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                test.Move(0);
            }
            else if(e.KeyCode == Keys.Left)
            {
                test.Move(-1);
            }
            else if (e.KeyCode == Keys.Right)
            {
                test.Move(1);
            }
            else if (e.KeyCode == Keys.Up)
            {
                test.Move(2);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.Blue), base.container);
            g.TranslateTransform(base.container.X, base.container.Y);

            //Draw the board
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    Block b = new Block(blocksize, Color.White, Color.Black);
                    b.Location = new Point(i*blocksize, j*blocksize);
                    b.Render(g);
                }
            }

            test.Render(g);
            Invalidate();
        }
    }
}

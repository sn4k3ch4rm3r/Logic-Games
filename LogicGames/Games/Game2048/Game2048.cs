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

namespace LogicGames.Games.Game2048
{
    public partial class Game2048 : GameView
    {
        private Tile tile;
        int cellSize;
        int[,] positions = new int[4, 4];
        List<Tile> tiles = new List<Tile>();
        public Game2048() : base()
        {
            this.Text = "2048";
            this.KeyDown += Game2048_KeyDown;
            DoubleBuffered = true;
            cellSize = base.container.Width / 4;
            NewTile();
        }
        
        private void Game2048_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                tile = tiles[i];
                int X = tiles[i].Coord[0];
                int Y = tiles[i].Coord[1];
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        while (!CanMove(tile, 1))
                        {
                            positions[tiles[i].Coord[0] - 1, tiles[i].Coord[1]] = tile.value;
                            positions[tiles[i].Coord[0], tiles[i].Coord[1]] = 0;
                            tile.Move(1);
                        }
                        break;
                    case Keys.Right:
                        while (!CanMove(tile, 2))
                        {
                            positions[tiles[i].Coord[0] + 1, tiles[i].Coord[1]] = tile.value;
                            positions[tiles[i].Coord[0], tiles[i].Coord[1]] = 0;
                            tile.Move(2);
                        }
                        break;
                    case Keys.Up:
                        while (!CanMove(tile, 3))
                        {
                            positions[tiles[i].Coord[0], tiles[i].Coord[1] - 1] = tile.value;
                            positions[tiles[i].Coord[0], tiles[i].Coord[1]] = 0;
                            tile.Move(3);
                        }
                        break;
                    case Keys.Down:
                        while (!CanMove(tile, 4))
                        {
                            positions[tiles[i].Coord[0], tiles[i].Coord[1] + 1] = tile.value;
                            positions[tiles[i].Coord[0], tiles[i].Coord[1]] = 0;
                            tile.Move(4);
                        }
                        break;
                    default:
                        break;
                }
            }
            NewTile();
        }

        TimeSpan lastFrameTime = TimeSpan.Zero;
        Stopwatch frameTimer = Stopwatch.StartNew();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            TimeSpan currentFrameTime = frameTimer.Elapsed;
            float deltaTime = (float)(currentFrameTime - lastFrameTime).TotalSeconds;

            container.Location = new Point(ClientRectangle.Width / 2 - container.Width / 2, ClientRectangle.Height / 2 - container.Height / 2);
            e.Graphics.FillRectangle(new SolidBrush(Color.White), container);

            Render(e, deltaTime);

            lastFrameTime = currentFrameTime;
            Invalidate();
        }

        protected void Render(PaintEventArgs e, float dt)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(base.container.X, base.container.Y + base.container.Height - base.container.Width);
            Pen p = new Pen(Color.Black, 1);

            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(p, i * cellSize, 0, i * cellSize, 4 * cellSize);
                g.DrawLine(p, 0, i * cellSize, 4 * cellSize, i * cellSize);
            }

            if (tiles.Count > 0)
            {
                for (int i = 0; i < tiles.Count; i++)
                {
                    tile = tiles[i];
                    tile.Render(g);
                }
            }

            //example of animation
            /*xpos += dt*speed;
            if(xpos >= base.container.Width-100)
            {
                xpos = 0;
            }
            e.Graphics.DrawRectangle(new Pen(Color.Red, 2), xpos, 375, cellSize, cellSize);*/
        }
        
        public bool CanMove(Tile t, int num)
        {
            switch (num)
            {
                case 1:
                    return t.Coord[0] == 0 || positions[t.Coord[0] - 1, t.Coord[1]] != 0;
                case 2:
                    return t.Coord[0] == 3 || positions[t.Coord[0] + 1, t.Coord[1]] != 0;
                case 3:
                    return t.Coord[1] == 0 || positions[t.Coord[0], t.Coord[1] - 1] != 0;
                case 4:
                    return t.Coord[1] == 3 || positions[t.Coord[0], t.Coord[1] + 1] != 0;
                default:
                    return false;
            }
        }
        public void NewTile()
        {
            Random r = new Random();
            int[] x = new int[2];
            do
            {
                x[0] = r.Next(0, 4);
                x[1] = r.Next(0, 4);
            }
            while (positions[x[0], x[1]] != 0);   
            tiles.Add(new Tile(cellSize, 2, x, Color.Red, Color.Red));
            positions[x[0], x[1]] = 2;
        }
    }
}

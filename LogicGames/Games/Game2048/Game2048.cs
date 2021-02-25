using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LogicGames.Games.Game2048
{
    public partial class Game2048 : GameView
    {
        private Tile tile;
        private int score = 0;
        private int currentTiles;
        private int cellSize;
        private bool anyMove;
        Tile[,] positions = new Tile[4, 4];
        public Game2048() : base()
        {
            this.Text = "2048";
            this.KeyDown += Game2048_KeyDown;
            DoubleBuffered = true;
            cellSize = base.container.Width / 4;
            NewTile();
            NewTile();
        }

        private void Game2048_KeyDown(object sender, KeyEventArgs e)
        {
            anyMove = false;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    moveLeft();
                    break;
                case Keys.Right:
                    moveRight();
                    break;
                case Keys.Up:
                    moveUp();
                    break;
                case Keys.Down:
                    
                    break;
            }
            if (anyMove)
            {
                NewTile();
            }
            if (currentTiles == 16 && gameOver())
            {
                score = 0;
                positions = new Tile[4, 4];
                currentTiles = 0;
                NewTile();
            }
        }
        public void moveLeft()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (positions[i, j] != null)
                    {
                        int x = 0;
                        bool didMerge = false;
                        while (i - x - 1 >= 0 && (positions[i - x - 1, j] == null || positions[i - x - 1, j].value == positions[i, j].value) && !didMerge)
                        {
                            x++;
                            if (positions[i - x, j] != null && positions[i - x, j].value == positions[i, j].value)
                            {
                                didMerge = true;
                            }
                        }
                        if (x > 0)
                        {
                            positions[i, j].Coord[0] -= x;
                            positions[i - x, j] = positions[i, j];
                            positions[i, j] = null;
                            if (didMerge)
                            {
                                positions[i - x, j].value *= 2;
                                score += positions[i - x, j].value;
                                currentTiles--;
                            }
                            anyMove = true;
                        }
                    }
                }
            }
        }
        public void moveRight()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 3; i >= 0; i--)
                {
                    if (positions[i, j] != null)
                    {
                        int x = 0;
                        bool didMerge = false;
                        while (i + x + 1 < 4 && (positions[i + x + 1, j] == null || positions[i + x + 1, j].value == positions[i, j].value) && !didMerge)
                        {
                            x++;
                            if (positions[i + x, j] != null && positions[i + x, j].value == positions[i, j].value)
                            {
                                didMerge = true;
                            }
                        }
                        if (x > 0)
                        {
                            positions[i, j].Coord[0] += x;
                            positions[i + x, j] = positions[i, j];
                            positions[i, j] = null;
                            if (didMerge)
                            {
                                positions[i + x, j].value *= 2;
                                score += positions[i + x, j].value;
                                currentTiles--;
                            }
                            anyMove = true;
                        }
                    }
                }
            }
        }

        public void moveUp()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (positions[i, j] != null)
                    {
                        int x = 0;
                        bool didMerge = false;
                        while (j - x - 1 >= 0 && (positions[i, j - x - 1] == null || positions[i, j - x - 1].value == positions[i, j].value) && !didMerge)
                        {
                            x++;
                            if (positions[i, j - x] != null && positions[i, j - x].value == positions[i, j].value)
                            {
                                didMerge = true;
                            }
                        }
                        if (x > 0)
                        {
                            positions[i, j].Coord[1] -= x;
                            positions[i, j - x] = positions[i, j];
                            positions[i, j] = null;
                            if (didMerge)
                            {
                                positions[i, j - x].value *= 2;
                                score += positions[i, j - x].value;
                                currentTiles--;
                            }
                            anyMove = true;
                        }
                    }
                }
            }
        }

        public void moveDown()
        {
            for (int j = 3; j >= 0; j--)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (positions[i, j] != null)
                    {
                        int x = 0;
                        bool didMerge = false;
                        while (j + x + 1 < 4 && (positions[i, j + x + 1] == null || positions[i, j + x + 1].value == positions[i, j].value) && !didMerge)
                        {
                            x++;
                            if (positions[i, j + x] != null && positions[i, j + x].value == positions[i, j].value)
                            {
                                didMerge = true;
                            }
                        }
                        if (x > 0)
                        {
                            positions[i, j].Coord[1] += x;
                            positions[i, j + x] = positions[i, j];
                            positions[i, j] = null;
                            if (didMerge)
                            {
                                positions[i, j + x].value *= 2;
                                score += positions[i, j + x].value;
                                currentTiles--;
                            }
                            anyMove = true;
                        }
                    }
                }
            }
        }
        public bool gameOver()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i < 3)
                    {
                        if (positions[i, j].value == positions[i + 1, j].value)
                        {
                            return false;
                        }
                    }
                    if (j < 3)
                    {
                        if (positions[i, j].value == positions[i, j + 1].value)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        TimeSpan lastFrameTime = TimeSpan.Zero;
        Stopwatch frameTimer = Stopwatch.StartNew();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            TimeSpan currentFrameTime = frameTimer.Elapsed;
            float deltaTime = (float)(currentFrameTime - lastFrameTime).TotalSeconds;

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
            FontFamily font = new FontFamily("Arial");
            g.DrawString($"Pont: {score}", new Font(font, 16, FontStyle.Bold), new SolidBrush(Color.Black), 10, -60);

            if (positions.Length > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        tile = positions[i, j];
                        if (tile != null) tile.Render(g);
                    }
                }
            }
        }

        public void NewTile()
        {
            Random r = new Random();
            int x;
            int y;
            do
            {
                x = r.Next(0, 4);
                y = r.Next(0, 4);
            }
            while (positions[x, y] != null);
            positions[x, y] = new Tile(cellSize, 9 > r.Next(0, 10) ? 2 : 4, new int[] { x, y });
            currentTiles++;
        }
    }
}
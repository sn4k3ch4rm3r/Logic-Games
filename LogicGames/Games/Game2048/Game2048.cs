using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using LogicGames.Database.Models;
using LogicGames.Database.GameClients;

namespace LogicGames.Games.Game2048
{
    public partial class Game2048 : GameView
    {
        private const float animationTime = .1f;
        private const int border = 12;
        private Tile tile;
        private Game2048Model model;
        private int currentTiles;
        private int cellSize;
        private bool anyMove;
        private bool didWin = false;
        private bool seenMenu = false;
        private bool isMenuShowing = false;
        private bool nextTile = false;
        private float timeSinceMove = 0;
        private Stopwatch stopwatch = new Stopwatch();
        Tile[,] positions = new Tile[4, 4];
        public Game2048() : base()
        {
            model = new Game2048Model();
            this.Text = "2048";
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(Game2048_KeyDown);
            DoubleBuffered = true;
            cellSize = base.container.Width / 4;
            NewTile(2);
            stopwatch.Start();
        }

        private void Game2048_KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (isMenuShowing) return;
            if (timeSinceMove < animationTime) NewTile(1);
            anyMove = false;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    MoveLeft();
                    break;
                case Keys.Right:
                    MoveRight();
                    break;
                case Keys.Up:
                    MoveUp();
                    break;
                case Keys.Down:
                    MoveDown();
                    break;
            }
            if (anyMove)
            {
                nextTile = true;
                timeSinceMove = 0;
            }
            if (didWin && !seenMenu)
            {
                isMenuShowing = true;
                base.ShowMenu(new Menus.GameMenu(subtitle: "Nyertél\nFolytathatod a játékot,\nvagy újat kezdhetsz", "Folytatás", "Új játék", "Kilépés"));
            }
            if (currentTiles == 16 && gameOver())
            {
                isMenuShowing = true;
                base.ShowMenu(new Menus.GameMenu(subtitle: "Veszítettél", "Új játék", "Kilépés"));
            }
        }

        protected override void MenuSelected(int selected)
        {
            if (((!didWin || seenMenu) && selected == 0) || (!seenMenu && didWin && selected == 1))
            {
                model.Time = (int)stopwatch.Elapsed.TotalSeconds;
                model.Save();
                positions = new Tile[4, 4];
                model = new Game2048Model();
                currentTiles = 0;
                seenMenu = false;
                didWin = false;
                isMenuShowing = false;
                stopwatch.Restart();
                NewTile(2);
                return;
            }
            else if (((!didWin || seenMenu) && selected == 1) || (didWin && selected == 2))
            {
                model.Time = (int)stopwatch.Elapsed.TotalSeconds;
                model.Save();
                this.Close();
            }
            seenMenu = true;
            didWin = false;
            isMenuShowing = false;
        }

        public void MoveLeft()
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
                            positions[i, j].Move(-x, 0);
                            positions[i - x, j] = positions[i, j];
                            positions[i, j] = null;
                            if (didMerge)
                            {
                                positions[i - x, j].value *= 2;
                                model.Tiles[positions[i - x, j].value > 2048 ? -1 : positions[i - x, j].value]++;
                                model.Score += positions[i - x, j].value;
                                currentTiles--;
                                if (positions[i - x, j].value == 2048 && !didWin)
                                {
                                    didWin = true;
                                }
                            }
                            anyMove = true;
                        }
                    }
                }
            }
        }
        public void MoveRight()
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
                            positions[i, j].Move(x, 0);
                            positions[i + x, j] = positions[i, j];
                            positions[i, j] = null;
                            if (didMerge)
                            {
                                positions[i + x, j].value *= 2;
                                model.Tiles[positions[i + x, j].value > 2048 ? -1 : positions[i + x, j].value]++;
                                model.Score += positions[i + x, j].value;
                                currentTiles--;
                                if (positions[i + x, j].value == 2048 && !didWin)
                                {
                                    didWin = true;
                                }
                            }
                            anyMove = true;
                        }
                    }
                }
            }
        }

        public void MoveUp()
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
                            positions[i, j].Move(0, -x);
                            positions[i, j - x] = positions[i, j];
                            positions[i, j] = null;
                            if (didMerge)
                            {
                                positions[i, j - x].value *= 2;
                                model.Tiles[positions[i, j - x].value > 2048 ? -1 : positions[i, j - x].value]++;
                                model.Score += positions[i, j - x].value;
                                currentTiles--;
                                if (positions[i, j - x].value == 2048 && !didWin)
                                {
                                    didWin = true;
                                }
                            }
                            anyMove = true;
                        }
                    }
                }
            }
        }

        public void MoveDown()
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
                            positions[i, j].Move(0, x);
                            positions[i, j + x] = positions[i, j];
                            positions[i, j] = null;
                            if (didMerge)
                            {
                                positions[i, j + x].value *= 2;
                                model.Tiles[positions[i, j + x].value > 2048 ? -1 : positions[i, j + x].value]++;
                                model.Score += positions[i, j + x].value;
                                currentTiles--;
                                if (positions[i, j + x].value == 2048 && !didWin)
                                {
                                    didWin = true;
                                }
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

            timeSinceMove += deltaTime;
            if (nextTile && timeSinceMove >= animationTime) NewTile(1);

            Render(e, deltaTime);

            lastFrameTime = currentFrameTime;
            if(!isMenuShowing) Invalidate();
        }

        protected void Render(PaintEventArgs e, float deltaTime)
        {
            Graphics g = e.Graphics;

            Font font = new Font("Arial", 16, FontStyle.Bold);
            string score = $"Pont: {model.Score}\nRekord: {Game2048Client.Highscore}";
            SizeF stringSize = e.Graphics.MeasureString(score, font);
            g.DrawString(score, font, new SolidBrush(Resources.Colors.PrimaryText), base.container.Left + (base.container.Width / 2) - (stringSize.Width / 2), base.container.Top + ((base.container.Height - base.container.Width) / 2) - (stringSize.Height / 2));
            
            g.TranslateTransform(base.container.X, base.container.Y + base.container.Height - base.container.Width);
            
            Pen p = new Pen(Resources.Colors.PrimaryText, border);
            int borderPos = border / 2;
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(p, borderPos, 0, borderPos, 4 * cellSize);
                g.DrawLine(p, 0, borderPos, 4 * cellSize, borderPos);
                borderPos += cellSize - (border/4);
            }

            if (positions.Length > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        tile = positions[i, j];
                        if (tile != null) tile.Render(g, deltaTime, animationTime);
                    }
                }
            }
        }

        public void NewTile(int n)
        {
            nextTile = false;
            Random r = new Random();
            int x;
            int y;
            for (int i = 0; i < n; i++)
            {
                do
                {
                    x = r.Next(0, 4);
                    y = r.Next(0, 4);
                }
                while (positions[x, y] != null);
                positions[x, y] = new Tile(cellSize, border, r.Next(0, 10) < 9 ? 2 : 4, new Point(x, y));
                currentTiles++;
            }
        }
    }
}

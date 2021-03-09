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
using LogicGames.Database.Models;
using LogicGames.Database.GameClients;

namespace LogicGames.Games.Tetris
{
    public partial class Tetris : GameView
    {
        private Stopwatch timer;
        private TimeSpan lastMoveTime;
        private float tickTime = 0.5f;

        private Board board;

        private Tetrimino currentShape;
        private Tetrimino nextShape;

        private TetrisModel model;

        private bool gameOver;

        private System.Media.SoundPlayer player;

        public Tetris() : base()
        {
            this.Text = "Tetris";

            DoubleBuffered = true;
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(OnKeyDown);

            StartGame();

            System.IO.Stream stream = Properties.Resources.Tetris_99_Main_Theme;
            player = new System.Media.SoundPlayer(stream);
            player.PlayLooping();
        }

        private void NextShape()
        {
            currentShape = nextShape;
            currentShape.MakeCurrent();
            model.Shapes[currentShape.Shape.Name]++;
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
                    model.Score += (int)Math.Pow(2, linesCleared - 1) * 100;
                    model.Cleared += linesCleared;
                }

                if (!currentShape.Moved || currentShape.Location.Y < 0)
                {
                    GameOver();
                    return;
                }
                NextShape();
            }
        }

        private void OnKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                MoveDown();
                model.Score += 2;
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
            model.Time = (int)timer.Elapsed.TotalSeconds;
            model.Save();
            Menus.GameMenu gameOverMenu = new Menus.GameMenu(subtitle: $"Elért pontok: {model.Score}\nTörölt sorok: {model.Cleared}", "Új játék", "Kilépés");
            base.ShowMenu(gameOverMenu);
        }

        private void StartGame()
        {
            timer = new Stopwatch();
            lastMoveTime = new TimeSpan(0);
            
            board = new Board(10, 20, base.container);
            model = new TetrisModel();
            
            nextShape = new Tetrimino(board, Shapes.Random());
            NextShape();
            gameOver = false;

            timer.Start();
        }

        protected override void MenuSelected(int selected)
        {
            switch(selected)
            {
                case 0:
                    StartGame();
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
                model.Score++;
                lastMoveTime = timer.Elapsed;
            }

            board.Render(g);
            currentShape.Render(g);
            nextShape.Render(g);

            Font font = new Font("Arial", 15);
            SolidBrush textBrush = new SolidBrush(Resources.Colors.PrimaryText);
            SizeF stringSize = g.MeasureString("Következő:", font);
            int beginText = (board.Size.Width * board.BlockSize) + (base.container.Width - board.Size.Width * board.BlockSize) / 2;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            g.DrawString("Következő:", font, textBrush, beginText, board.NextDisplayRect.Top - stringSize.Height, sf);
            g.DrawString($"Pontszám: {model.Score}\nRekord: {TetrisClient.Highscore}\nSorok: {model.Cleared}", font, textBrush, beginText, 30, sf);
            if(!gameOver) { 
                Invalidate();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            player.Stop();
            base.OnClosed(e);
        }
    }
}

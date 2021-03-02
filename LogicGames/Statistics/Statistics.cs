using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGames.Statistics
{
    public partial class Statistics : Games.GameView
    {
        private int headerHeight = 50;
     
        private struct String
        {
            private Point offset;
            private Font font;
            private SolidBrush brush;
            private string text;
            private int height;

            public String(string text, Font font, Color color, int x, int y)
            {
                this.text = text;
                this.font = font;
                this.brush = new SolidBrush(color);
                this.offset = new Point(x,y);
                this.height = 0;
            }

            public void Render(Graphics g)
            {
                SizeF size = g.MeasureString(text, font);
                g.DrawString(text, font, brush, offset);
                g.TranslateTransform(0, offset.Y + size.Height);
            }
        }

        private List<String> texts;

        public Statistics(): base()
        {
            InitializeComponent();
            this.BackColor = Resources.Colors.Background;
            Button backButton = new Resources.CustomButton();
            backButton.Location = new Point(0, 0);
            backButton.Size = new Size(headerHeight, headerHeight);
            backButton.Text = "❮";
            backButton.Font = new Font("Arial", 20, FontStyle.Bold);
            backButton.Click += backButtonClick;
            this.Controls.Add(backButton);

            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            Font font = new Font("Arial", 12);

            texts = new List<String>();
            //2048
            texts.Add(new String("2048", titleFont, Resources.Colors.PrimaryText, 0, 10));
            texts.Add(new String($"Rekord: {Database.GameClients.Game2048Client.Highscore}", font, Resources.Colors.PrimaryText, 0, 5));
            texts.Add(new String($"Megnyert játékok: {Database.GameClients.Game2048Client.GamesWon}", font, Resources.Colors.PrimaryText, 0, 0));
            texts.Add(new String($"Játékidő: {Database.GameClients.Game2048Client.Playtime / 60} perc", font, Resources.Colors.PrimaryText, 0, 0));
            texts.Add(new String($"Játszott játékok: {Database.GameClients.Game2048Client.GamesPlayed}", font, Resources.Colors.PrimaryText, 0, 0));
            //Tetris
            texts.Add(new String("Tetris", titleFont, Resources.Colors.PrimaryText, 0, 30));
            texts.Add(new String($"Rekord: {Database.GameClients.TetrisClient.Highscore}", font, Resources.Colors.PrimaryText, 0, 5));
            texts.Add(new String($"Törölt sorok: {Database.GameClients.TetrisClient.LinesCleared}", font, Resources.Colors.PrimaryText, 0, 0));
            texts.Add(new String($"Játékidő: {Database.GameClients.TetrisClient.Playtime / 60} perc", font, Resources.Colors.PrimaryText, 0, 0));
            texts.Add(new String($"Játszott játékok: {Database.GameClients.TetrisClient.GamesPlayed}", font, Resources.Colors.PrimaryText, 0, 0));
            //Minesweeper
            texts.Add(new String("Aknakereső", titleFont, Resources.Colors.PrimaryText, 0, 30));
            texts.Add(new String($"Legjobb idő: {Database.GameClients.MinesweeperClient.Highscore}", font, Resources.Colors.PrimaryText, 0, 5));
            texts.Add(new String($"Megnyert játékok: {Database.GameClients.MinesweeperClient.GamesWon}", font, Resources.Colors.PrimaryText, 0, 0));
            texts.Add(new String($"Felfedezett mezők: {Database.GameClients.MinesweeperClient.SquaresDiscovered}", font, Resources.Colors.PrimaryText, 0, 0));
            texts.Add(new String($"Lerakott zászlók: {Database.GameClients.MinesweeperClient.FlagsPlaced}", font, Resources.Colors.PrimaryText, 0, 0));
            texts.Add(new String($"Játékidő: {Database.GameClients.MinesweeperClient.Playtime / 60} perc", font, Resources.Colors.PrimaryText, 0, 0));
            texts.Add(new String($"Játszott játékok: {Database.GameClients.MinesweeperClient.GamesPlayed}", font, Resources.Colors.PrimaryText, 0, 0));
        }

        private void backButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Resources.Colors.ContainterBackground), 0, 0, this.ClientRectangle.Width, headerHeight);
            e.Graphics.TranslateTransform(base.container.Left, base.container.Top);

            foreach (String text in texts)
            {
                text.Render(e.Graphics);
            }
        }

        protected override void onResize(object sender, EventArgs e)
        {
            base.onResize(sender, e);
            base.container.Y = 50;
            Refresh();
        }
    }
}

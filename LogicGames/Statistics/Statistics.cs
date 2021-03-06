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

            public String(string text, Font font, Color color, int offset = 0)
            {
                this.text = text;
                this.font = font;
                this.brush = new SolidBrush(color);
                this.offset = new Point(0,offset);
            }

            public void Render(Graphics g, Rectangle containter)
            {
                SizeF size = g.MeasureString(text, font);
                offset.X = (containter.Width / 2) - (int)(size.Width / 2);
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
            texts.Add(new String("2048", titleFont, Resources.Colors.PrimaryText, 10));
            texts.Add(new String($"Rekord: {Database.GameClients.Game2048Client.Highscore}", font, Resources.Colors.PrimaryText, 5));
            texts.Add(new String($"Megnyert játékok: {Database.GameClients.Game2048Client.GamesWon}", font, Resources.Colors.PrimaryText));
            texts.Add(new String($"Játékidő: {Database.GameClients.Game2048Client.Playtime / 60} perc", font, Resources.Colors.PrimaryText));
            texts.Add(new String($"Játszott játékok: {Database.GameClients.Game2048Client.GamesPlayed}", font, Resources.Colors.PrimaryText));
            //Tetris
            texts.Add(new String("Tetris", titleFont, Resources.Colors.PrimaryText, 30));
            texts.Add(new String($"Rekord: {Database.GameClients.TetrisClient.Highscore}", font, Resources.Colors.PrimaryText, 5));
            texts.Add(new String($"Törölt sorok: {Database.GameClients.TetrisClient.LinesCleared}", font, Resources.Colors.PrimaryText));
            texts.Add(new String($"Játékidő: {Database.GameClients.TetrisClient.Playtime / 60} perc", font, Resources.Colors.PrimaryText));
            texts.Add(new String($"Játszott játékok: {Database.GameClients.TetrisClient.GamesPlayed}", font, Resources.Colors.PrimaryText));
            //Minesweeper
            texts.Add(new String("Aknakereső", titleFont, Resources.Colors.PrimaryText, 30));
            texts.Add(new String($"Legjobb idő: {Database.GameClients.MinesweeperClient.Highscore}", font, Resources.Colors.PrimaryText, 5));
            texts.Add(new String($"Megnyert játékok: {Database.GameClients.MinesweeperClient.GamesWon}", font, Resources.Colors.PrimaryText));
            texts.Add(new String($"Felfedezett mezők: {Database.GameClients.MinesweeperClient.SquaresDiscovered}", font, Resources.Colors.PrimaryText));
            texts.Add(new String($"Lerakott zászlók: {Database.GameClients.MinesweeperClient.FlagsPlaced}", font, Resources.Colors.PrimaryText));
            texts.Add(new String($"Játékidő: {Database.GameClients.MinesweeperClient.Playtime / 60} perc", font, Resources.Colors.PrimaryText));
            texts.Add(new String($"Játszott játékok: {Database.GameClients.MinesweeperClient.GamesPlayed}", font, Resources.Colors.PrimaryText));
        }

        private void backButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Resources.Colors.ContainterBackground), 0, 0, this.ClientRectangle.Width, headerHeight);
            string header = "Statisztika";
            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            SizeF headerSize = e.Graphics.MeasureString(header, headerFont);
            e.Graphics.DrawString(header, headerFont, new SolidBrush(Resources.Colors.PrimaryText), (ClientRectangle.Width / 2) - (headerSize.Width / 2), (headerHeight / 2) - (headerSize.Height / 2));
            e.Graphics.TranslateTransform(base.container.Left, base.container.Top);

            foreach (String text in texts)
            {
                text.Render(e.Graphics, base.container);
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

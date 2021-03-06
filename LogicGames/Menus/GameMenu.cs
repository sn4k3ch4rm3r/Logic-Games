using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGames.Menus
{
    public partial class GameMenu : Form
    {
        public Size ContentSize { get; private set; }
        private Size buttonSize = new Size(150, 50);
        private int border = 10;
        private List<Button> buttons = new List<Button>();
        public int Selected { get; private set; }

        public GameMenu(string subtitle = "", params string[] buttonTexts)
        {
            InitializeComponent();
            this.BackColor = Resources.Colors.Background;

            Label title = new Label();
            title.Text = "Game Over";
            title.Location = new Point(border,border);
            title.Font = new Font("Arial", 25, FontStyle.Bold);
            title.ForeColor = Resources.Colors.PrimaryText;
            this.Controls.Add(title);
            title.AutoSize = true;

            Label subtitleLabel = new Label();
            if (subtitle != "" && subtitle != null)
            {
                subtitleLabel.Text = subtitle;
                subtitleLabel.Location = new Point(border, 2*border + title.Height);
                subtitleLabel.Font = new Font("Arial", 14);
                subtitleLabel.ForeColor = Resources.Colors.PrimaryText;
                subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(subtitleLabel);
                subtitleLabel.AutoSize = true;
                Size size = new Size(title.Size.Width, subtitleLabel.Size.Height);
                subtitleLabel.AutoSize = false;
                subtitleLabel.Size = size;
            }
            else
            {
                subtitleLabel.Size = new Size(0, 0);
            }

            buttonSize.Width = title.Width;

            int y = border + title.Size.Height + subtitleLabel.Size.Height + (subtitleLabel.Size.Height == 0?0:2*border);
            foreach(string text in buttonTexts)
            {
                Button button = new Resources.CustomButton();
                button.Text = text;
                button.Font = new Font("Arial", 12, FontStyle.Bold);
                button.Location = new Point(border,border + y);
                button.Size = buttonSize;
                button.Click += OnButtonClick;
                y += buttonSize.Height + border;
                buttons.Add(button);
                this.Controls.Add(button);
            }
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;

            ContentSize = new Size(title.Width + 2 * border, title.Size.Height + subtitleLabel.Height + (subtitleLabel.Size.Height == 0 ? 0 : 2 * border) + ((2 + buttons.Count) * border) + (buttonTexts.Length * buttonSize.Height));
        }
        private void OnButtonClick(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            Selected = buttons.IndexOf(clicked);
            this.Close();
        }
    }
}

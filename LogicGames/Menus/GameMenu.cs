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
        public Size ContentSize { get; }
        private Size buttonSize = new Size(150, 50);
        private int border = 10;
        private List<Button> buttons = new List<Button>();
        public int Selected { get; private set; }
        public GameMenu(params string[] buttonTexts)
        {
            InitializeComponent();
            this.BackColor = Resources.Colors.Background;
            ContentSize = new Size(150,50);
            int y = 0;
            foreach(string text in buttonTexts)
            {
                Button button = new Resources.CustomButton();
                button.Text = text;
                button.Font = new Font("Arial", 12, FontStyle.Bold);
                button.Location = new Point(border,border + y);
                button.Size = ContentSize;
                button.Click += OnButtonClick;
                y += ContentSize.Height + border;
                buttons.Add(button);
                this.Controls.Add(button);
            }
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ContentSize = new Size((2 * border) + ContentSize.Width, ((2 + buttons.Count - 1) * border) + (buttonTexts.Length * buttonSize.Height));
        }
        private void OnButtonClick(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            Selected = buttons.IndexOf(clicked);
            this.Close();
        }
    }
}

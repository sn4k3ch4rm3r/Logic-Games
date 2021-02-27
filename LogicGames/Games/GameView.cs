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
using LogicGames.Resources;
using LogicGames.Menus;

namespace LogicGames.Games
{
    public partial class GameView : Form
    {
        protected Rectangle container;

        private int width = 500;
        private int height = 600;
        public GameView()
        {
            InitializeComponent();
            SetContainerLocation();
            menu_panel.Hide();
            this.Resize += onResize;
        }

        private void onResize(object sender, EventArgs e)
        {
            SetContainerLocation();
            Refresh();
        }
        private void SetContainerLocation()
        {
            container = new Rectangle((ClientRectangle.Width / 2) - (width / 2), (ClientRectangle.Height / 2) - (height / 2), width, height);
            menu_panel.Location = new Point
            (
                (this.ClientRectangle.Width / 2) - (menu_panel.Size.Width / 2),
                (this.ClientRectangle.Height / 2) - (menu_panel.Size.Height / 2)
            );
        }

        protected void ShowMenu(GameMenu menu)
        {
            menu_panel.Controls.Add(menu);
            menu_panel.Size = menu.ContentSize;
            SetContainerLocation();
            menu.FormClosed += MenuButtonClicked;
            menu.Show();
            menu_panel.Show();
        }

        private void MenuButtonClicked(object sender, EventArgs e) 
        {
            GameMenu menu = sender as GameMenu;
            menu_panel.Hide();
            this.Focus();
            MenuSelected(menu.Selected);
            Invalidate();
        }

        protected virtual void MenuSelected(int selected) { }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = Colors.Background;
            e.Graphics.FillRectangle(new SolidBrush(Colors.ContainterBackground), container);
        }
    }
}

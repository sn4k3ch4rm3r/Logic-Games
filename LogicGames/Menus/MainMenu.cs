using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicGames.Games.Game2048;
using LogicGames.Games.Minesweeper;
using LogicGames.Games.Tetris;

namespace LogicGames.Menus
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        
        private void gameClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void showGame(Form gameForm)
        {
            this.Controls.Clear();
            gameForm.TopLevel = false;
            gameForm.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(gameForm);
            gameForm.Dock = DockStyle.Fill;
            gameForm.BringToFront();
            gameForm.Show();
            this.Controls[0].Focus();
            gameForm.FormClosed += gameClosed;
        }

        private void game2048_Click(object sender, EventArgs e)
        {
            showGame(new Game2048());
        }

        private void gameTetris_Click(object sender, EventArgs e)
        {
            showGame(new Tetris());
        }

        private void gameMinesweeper_Click(object sender, EventArgs e)
        {
            showGame(new Minesweeper());
        }
    }
}

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
            this.Show();
        }

        private void showGame(Form gameForm)
        {
            gameForm.Show();
            gameForm.FormClosed += gameClosed;
            this.Hide();
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

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

namespace LogicGames.Games.Minesweeper
{
    public partial class Minesweeper : GameView
    {
        public Minesweeper() : base()
        {
            this.Text = "Aknakereső";
            Button_Create();
        }

        private void Button_Create()
        {
            int width = base.Width;
            int height = base.Height;
            bool dark = true;
            for (int i = 20; i >= 1; i--)
            {
                for (int j = 25; j >= 1; j--)
                {
                    Button newButton = new Button();
                    newButton.Location = new Point((width / 20) * i, (height / 25) * j);
                    newButton.Size = new Size(width / 20, height / 25);
                    newButton.FlatStyle = new FlatStyle();
                    newButton.FlatAppearance.BorderSize = 0;
                    if (dark)
                    {
                        newButton.BackColor = Color.FromArgb(162, 209, 73);
                    }
                    else
                    {
                        newButton.BackColor = Color.FromArgb(170, 215, 81);
                    }
                    dark = !dark;
                    newButton.Click += new System.EventHandler(MyButton_Click);
                    newButton.Name = i.ToString() + "," + j.ToString();
                    this.Controls.Add(newButton);
                }
            }
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Button).Name);
        }
    }
}
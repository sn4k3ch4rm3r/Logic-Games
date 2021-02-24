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

        static int[,] field = new int[20,25]; //1 = mine, 0 = free space
        System.Windows.Forms.Button[,] btnArray = new System.Windows.Forms.Button[20,25];
        static Button LeftClickedButton, RightClickedButton;
        static bool generate = true;

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
                    newButton.MouseDown += new MouseEventHandler(MyButton_Click);
                    newButton.Name = i.ToString() + "," + j.ToString();
                    btnArray[i - 1, j - 1] = newButton;
                    this.Controls.Add(newButton);
                }
            }
        }

        public void Reset(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl is Button)
                {
                    ctrl.Text = String.Empty;
                }
            }
            generate = true;
        }

        private void FillUp()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    field[i, j] = 0;
                }
            }
        }

        private void Mines_Generate(int column, int row) //Changes the mines location's value to 1
        {
            FillUp();
            Random rnd = new Random();
            int i = 0;
            while (i < 20)
            {
                int column_add = rnd.Next(1, 21);
                int row_add = rnd.Next(1, 26);

                if (!(column == column_add && row == row_add))
                {
                    field[column_add - 1, row_add - 1] = 1;
                    i++;
                }
            }
        }

        private int[] GetCoords(string coords) //Seperates the button's name and gets the row's and column's value and returns them in an array
        {
            string[] coord = coords.Split(',');
            int column = int.Parse(coord[0]);
            int row = int.Parse(coord[1]);
            return new int[] { column, row };
        }

        private void Ending()
        {
            MessageBox.Show("Vége!");
            Reset(this.Controls);
        }

        private void check(int column, int row, int count, int clicked_column, int clicked_row)
        {
            if (row + 1 <= 24)
            {
                if (field[column, row + 1] == 1)
                {
                    count++;
                }
                else
                {
                    btnArray[column, row].BackColor = Color.FromArgb(215, 184, 153);
                    row++;
                    check(column, row, 0, clicked_column, clicked_row);
                }
            }
            if (row - 1 >= 0)
            {
                if (field[column, row - 1] == 1)
                {
                    count++;
                }
                else
                {
                    btnArray[column, row].BackColor = Color.FromArgb(215, 184, 153);
                    row--;
                    check(column, row, 0, clicked_column, clicked_row);
                }
            }
            if (column + 1 <= 19)
            {
                if (field[column + 1, row] == 1)
                {
                    count++;
                }
                else
                {
                    btnArray[column, row].BackColor = Color.FromArgb(215, 184, 153);
                    column++;
                    check(column, row, 0, clicked_column, clicked_row);
                }
            }
            if (column - 1 >= 00)
            {
                if (field[column + 1, row] == 1)
                {
                    count++;
                }
                else
                {
                    btnArray[column, row].BackColor = Color.FromArgb(215, 184, 153);
                    column--;
                    check(column, row, 0, clicked_column, clicked_row);
                }
            }
            if (column - 1 >= 0 && row + 1 <= 24)
            {
                if (field[column - 1, row + 1] == 1)
                {
                    count++;
                }
                else
                {
                    btnArray[column, row].BackColor = Color.FromArgb(215, 184, 153);
                    column--;
                    row++;
                    check(column, row, 0, clicked_column, clicked_row);
                }
            }
            if (column + 1 <= 19 && row + 1 <= 24)
            {
                if (field[column + 1, row + 1] == 1)
                {
                    count++;
                }
                else
                {
                    btnArray[column, row].BackColor = Color.FromArgb(215, 184, 153);
                    column++;
                    row++;
                    check(column, row, 0, clicked_column, clicked_row);
                }
            }
            if (column - 1 >= 0 && row - 1 >= 0)
            {
                if (field[column - 1, row - 1] == 1)
                {
                    count++;
                }
                else
                {
                    btnArray[column, row].BackColor = Color.FromArgb(215, 184, 153);
                    column--;
                    row--;
                    check(column, row, 0, clicked_column, clicked_row);
                }
            }
            if (column + 1 <= 19 && row - 1 >= 0)
            {
                if (field[column + 1, row - 1] == 1)
                {
                    count++;
                }
                else
                {
                    btnArray[column, row].BackColor = Color.FromArgb(215, 184, 153);
                    column++;
                    row--;
                    check(column, row, 0, clicked_column, clicked_row);
                }
            }
            if (count > 0)
            {
                btnArray[column, row].Text = Convert.ToString(count);
                //check(clicked_column, clicked_row, 0, clicked_column, clicked_row, progress * -1);
            }
            else if (count == 0)
            {
                btnArray[column, row].BackColor = Color.FromArgb(215, 184, 153);
            }
        }

        private void MyButton_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                /*Button b = sender as Button; //Checking if right click works
                MessageBox.Show(b.Name);*/
                RightClickedButton = (Button)sender;
                RightClickedButton.Text = "🏴";
            }
            else if (e.Button == MouseButtons.Left)
            {
                //MessageBox.Show((sender as Button).Name); //Button name check
                string name = (sender as Button).Name;
                LeftClickedButton = (Button)sender;
                int column = GetCoords(name)[0];
                int row = GetCoords(name)[1];
                if (generate)
                {
                    Mines_Generate(column, row);
                    generate = false;
                }
                if (field[column - 1, row - 1] == 1)
                {
                    Ending();
                }
                check(column - 1, row - 1, 0, column - 1, row - 1);
                //MessageBox.Show("Column: " + column + " Row: " + row); //Coordinate check
            }
        }
    }
}
/*
if (row + 1 <= 24)
            {
                if (field[column, row + 1] == 1)
                {
                    count++;
                }
            }
            if (row - 1 >= 0)
            {
                if (field[column, row - 1] == 1)
                {
                    count++;
                }
            }
            if (column + 1 <= 19)
            {
                if (field[column + 1, row] == 1)
                {
                    count++;
                }
            }
            if (column - 1 >= 0 && row + 1 <=24)
            {
                if (field[column - 1, row + 1] == 1)
                {
                    count++;
                }
            }
            if (column + 1 <= 19 && row + 1 <= 24)
            {
                if (field[column + 1, row + 1] == 1)
                {
                    count++;
                }
            }
            if (column - 1 >= 0 && row - 1 >= 0)
            {
                if (field[column - 1, row - 1] == 1)
                {
                    count++;
                }
            }
            if (column - 1 >= 0 && row + 1 <= 24)
            {
                if (field[column - 1, row + 1] == 1)
                {
                    count++;
                }
            }
            if (column + 1 <= 19 && row - 1 >= 0)
            {
                if (field[column + 1, row - 1] == 1)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                LeftClickedButton.Text = Convert.ToString(count);
            }
            //LeftClickedButton.BackColor = Color.FromArgb(215, 184, 153);
*/ //Back up of original Check function if i break everything :)
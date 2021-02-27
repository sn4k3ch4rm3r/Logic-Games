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
        Button[,] btnArray;
        private int[,] field;
        public Minesweeper() : base()
        {
            this.Text = "Aknakereső";
            this.Resize += OnResize;
            btnArray = new Button[fieldSize.Width, fieldSize.Height];
            field = new int[fieldSize.Width, fieldSize.Height]; //1 = mine, 0 = free space
            Button_Create();
        }

        private Button RightClickedButton;
        private bool generate = true;
        private Size fieldSize = new Size(10, 10);
        private int mineCount = 20;

        private int cellSize;

        private void Button_Create()
        {
            cellSize = base.container.Width / fieldSize.Width;
            for (int i = 0; i < fieldSize.Width; i++)
            {
                for (int j = 0; j < fieldSize.Height; j++)
                {
                    Button newButton = new Button();
                    newButton.MouseDown += new MouseEventHandler(MyButton_Click);
                    newButton.Enabled = true;
                    newButton.Location = new Point(base.container.Left + (cellSize * i), base.container.Top + (base.container.Height - (cellSize * fieldSize.Height)) + (cellSize * j));
                    newButton.Size = new Size(cellSize, cellSize);
                    newButton.FlatStyle = new FlatStyle();
                    newButton.FlatAppearance.BorderSize = 0;
                    newButton.BackColor = (i + j) % 2 == 0 ? Color.FromArgb(170, 215, 81) : Color.FromArgb(162, 209, 73);
                    newButton.Name = i.ToString() + "," + j.ToString();

                    this.Controls.Add(newButton);
                    btnArray[i, j] = newButton;
                }
            }
            generate = true;
        }

        private void Mines_Generate(int column, int row) //Changes the mines location's value to 1
        {
            Random rnd = new Random();
            int i = 0;
            List<string> already_mine = new List<string>();
            while (i < mineCount)
            {
                int column_add = rnd.Next(fieldSize.Width), row_add = rnd.Next(fieldSize.Height);
                string coords = column_add.ToString() + "," + row_add.ToString();
                bool let_generate = true;

                for (int r = row - 1; r <= row + 1; r++)
                {
                    for (int c = column - 1; c <= column + 1; c++)
                    {
                        if (column_add == c && row_add == r)
                        {
                            let_generate = false;
                        }
                    }
                }

                if (let_generate == true && !already_mine.Contains(coords))
                {
                    field[column_add, row_add] = 1;
                    already_mine.Add(coords);
                    btnArray[column_add, row_add].Text = "A";
                    i++;
                }
            }
        }

        private int[] GetCoords(string coords) //Seperates the button's name and gets the row's and column's value and returns them in an array
        {
            string[] coord = coords.Split(',');
            int column = Convert.ToInt32(coord[0]);
            int row = int.Parse(coord[1]);
            return new int[] { column, row };
        }

        private void Ending()
        {
            base.ShowMenu(new Menus.GameMenu("Új játék", "Kilépés"));
        }

        public void Reset()
        {
            field = new int[fieldSize.Width, fieldSize.Height];
            for (int i = 0; i < fieldSize.Width; i++)
            {
                for (int j = 0; j < fieldSize.Height; j++)
                {
                    btnArray[i, j].Text = "";
                    btnArray[i, j].BackColor = (i + j) % 2 == 0 ? Color.FromArgb(170, 215, 81) : Color.FromArgb(162, 209, 73);
                    btnArray[i, j].Enabled = true;
                }
            }
            generate = true;
        }

        private bool isValid(int column, int row)
        {
            if (column <= fieldSize.Width - 1 && column >= 0 && row >= 0 && row <= fieldSize.Height - 1)
            {
                return true;
            }
            else return false;
        }

        private int check(int column, int row) //Checks if a tile is a mine in a 3x3 grid
        {
            int count = 0;
            for (int i = column - 1; i <= column + 1; i++)
            {
                for (int j = row - 1; j <= row + 1; j++)
                {
                    if (isValid(i, j) && field[i, j] == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void FindMines(int column, int row)
        {
            if (btnArray[column, row].Enabled)
            {
                btnArray[column, row].Enabled = false;
                btnArray[column, row].BackColor = (column + row) % 2 == 1 ? Color.FromArgb(215, 184, 153) : Color.FromArgb(229, 194, 159);
                int count = check(column, row);
                if (count == 0)
                {
                    for (int i = column - 1; i <= column + 1; i++)
                    {
                        for (int j = row - 1; j <= row + 1; j++)
                        {
                            if (isValid(i, j))
                            {
                                FindMines(i, j);
                            }
                        }
                    }
                }
                else
                {
                    btnArray[column, row].Text = count.ToString();
                }
            }
        }

        private void MyButton_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RightClickedButton = (Button)sender;
                RightClickedButton.Text = "🏴";
            }
            else if (e.Button == MouseButtons.Left)
            {
                string name = (sender as Button).Name;
                int column = GetCoords(name)[0];
                int row = GetCoords(name)[1];
                if (generate)
                {
                    Mines_Generate(column, row);
                    generate = false;
                }
                if (field[column, row] == 1)
                {
                    Ending();
                    return;
                }
                FindMines(column, row);
            }
        }

        protected override void MenuSelected(int selected)
        {
            switch(selected)
            {
                case 0:
                    Reset();
                    break;
                case 1:
                    this.Close();
                    break;
            }
        }

        private void OnResize(object sender, EventArgs e)
        {
            for (int i = 0; i < fieldSize.Width; i++)
            {
                for (int j = 0; j < fieldSize.Height; j++)
                {
                    btnArray[i, j].Location = new Point
                    (
                        base.container.Left + (cellSize * i),
                        base.container.Top + (base.container.Height - (cellSize * fieldSize.Height)) + (cellSize * j)
                    );
                }
            }
        }
    }
}

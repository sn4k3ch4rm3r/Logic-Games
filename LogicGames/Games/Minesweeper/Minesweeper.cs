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
using LogicGames.Database.Models;
using LogicGames.Database.GameClients;

namespace LogicGames.Games.Minesweeper
{
    public partial class Minesweeper : GameView
    {
        private MinesweeperModel model;

        Button[,] btnArray;
        Label lbMineCount = new Label();
        Label lbTime = new Label();
        Label lbBest = new Label();

        Timer timer = new Timer();
        Random rnd;

        private int timerCounter;
        private int[,] field;
        private Color[] colors = {Color.Blue, Color.Green, Color.Red, Color.Purple, Color.Maroon, Color.Turquoise, Color.Black, Color.Gray};

        private bool generate = true;
        private Size fieldSize = new Size(10, 10);
        private int originalMineCount = 15;
        private int mineCount;

        private int cellSize;

        public Minesweeper() : base()
        {
            model = new MinesweeperModel();
            this.Text = "Aknakereső";
            this.Resize += OnResize;
            rnd = new Random();
            mineCount = originalMineCount;
            btnArray = new Button[fieldSize.Width, fieldSize.Height];
            field = new int[fieldSize.Width, fieldSize.Height]; //1 = mine, 0 = free space
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            Label_Create();
            Button_Create();
        }

        private void Label_Create()
        {
            Font font = new Font("Arial", 22, FontStyle.Bold);

            lbMineCount.Font = font;
            lbMineCount.BackColor = Resources.Colors.ContainterBackground;
            lbMineCount.ForeColor = Color.Red;
            lbMineCount.AutoSize = true;
            this.Controls.Add(lbMineCount);

            lbTime.Font = font; 
            lbTime.BackColor = Resources.Colors.ContainterBackground;
            lbTime.ForeColor = Resources.Colors.PrimaryText;
            lbTime.AutoSize = true;
            this.Controls.Add(lbTime);

            lbBest.Font = font;
            lbBest.BackColor = Resources.Colors.ContainterBackground;
            lbBest.ForeColor = Color.Gold;
            lbBest.AutoSize = true;
            this.Controls.Add(lbBest);

            SetText();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timerCounter++;
            SetText();
        }

        private void Button_Create()
        {
            cellSize = base.container.Width / fieldSize.Width;
            for (int i = 0; i < fieldSize.Width; i++)
            {
                for (int j = 0; j < fieldSize.Height; j++)
                {
                    Button newButton = new MinefieldButton();
                    newButton.Font = new Font("Arial", 18, FontStyle.Bold);
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
            int i = 0;
            List<string> already_mine = new List<string>();
            while (i < originalMineCount)
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

        private void Ending(string message)
        {
            model.Time = timerCounter;
            model.Flags = originalMineCount - mineCount;
            model.Save();
            foreach (Button button in btnArray)
            {
                button.Enabled = false;
            }
            base.ShowMenu(new Menus.GameMenu(subtitle: message, "Új játék", "Kilépés"));
        }

        private bool didWin()
        {
            for (int i = 0; i < fieldSize.Width; i++)
            {
                for (int j = 0; j < fieldSize.Height; j++)
                {
                    if ((btnArray[i, j].BackColor == Color.FromArgb(170, 215, 81) || btnArray[i, j].BackColor == Color.FromArgb(162, 209, 73)) && field[i, j] != 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Reset()
        {
            model = new MinesweeperModel();
            field = new int[fieldSize.Width, fieldSize.Height];
            for (int i = 0; i < fieldSize.Width; i++)
            {
                for (int j = 0; j < fieldSize.Height; j++)
                {
                    btnArray[i, j].Text = "";
                    btnArray[i, j].BackColor = (i + j) % 2 == 0 ? Color.FromArgb(170, 215, 81) : Color.FromArgb(162, 209, 73);
                    btnArray[i, j].ForeColor = Color.Black;
                    btnArray[i, j].Enabled = true;
                }
            }
            generate = true;
            timerCounter = 0;
            mineCount = originalMineCount;
            SetText();
        }

        private void SetText()
        {
            int padding = 20;
            lbTime.Text = $"⏰: {timerCounter}";
            lbTime.Location = new Point(base.container.Left + (base.container.Width / 2) - (lbTime.Size.Width / 2), base.container.Top + ((base.container.Height - (fieldSize.Height * cellSize)) / 2) - (lbTime.Size.Height / 2));
            lbBest.Text = $"🏆: {MinesweeperClient.Highscore}";
            lbBest.Location = new Point(base.container.Right - lbBest.Size.Width - padding, base.container.Top + ((base.container.Height - (fieldSize.Height * cellSize)) / 2) - (lbBest.Size.Height / 2));
            lbMineCount.Text = $"🏴: {mineCount}";
            lbMineCount.Location = new Point(base.container.Left + padding, base.container.Top + ((base.container.Height - (fieldSize.Height * cellSize)) / 2) - (lbMineCount.Size.Height / 2));
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
                model.Checked++;
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
                                if (btnArray[i, j].Text == "🏴")
                                {
                                    btnArray[i, j].Text = "";
                                    mineCount++;
                                    lbMineCount.Text = $"🏴: {mineCount}";
                                }
                                FindMines(i, j);
                            }
                        }
                    }
                }
                else
                {
                    btnArray[column, row].ForeColor = colors[count - 1];
                    btnArray[column, row].Text = count.ToString();
                }
            }
        }

        private void checkLeftMines()
        {
            for (int i = 0; i < fieldSize.Width; i++)
            {
                for (int j = 0; j < fieldSize.Height; j++)
                {
                    if (field[i, j] == 1 && btnArray[i, j].Text != "🏴")
                    {
                        btnArray[i, j].ForeColor = Color.Black;
                        btnArray[i, j].Text = "💣";
                    }
                    else if (field[i, j] == 0 && btnArray[i, j].Text == "🏴")
                    {
                        btnArray[i, j].Text = "❌";
                    }
                }
            }
        }

        private void MyButton_Click(object sender, MouseEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (e.Button == MouseButtons.Right)
            {
                if (clickedButton.Text == "🏴")
                {
                    mineCount++;
                    lbMineCount.Text = $"🏴: {mineCount}";
                    clickedButton.Text = "";
                }
                else if (mineCount > 0)
                {
                    mineCount--;
                    lbMineCount.Text = $"🏴: {mineCount}";
                    clickedButton.Text = "🏴";
                }
                clickedButton.ForeColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left && clickedButton.Text != "🏴")
            {
                string name = clickedButton.Name;
                int column = GetCoords(name)[0];
                int row = GetCoords(name)[1];
                if (generate)
                {
                    Mines_Generate(column, row);
                    generate = false;
                    timer.Enabled = true;
                }
                if (field[column, row] == 1)
                {
                    timer.Enabled = false;
                    model.Mine = true;
                    checkLeftMines();
                    Ending($"Vesztettél\nEltelt idő: {timerCounter} mp");
                    return;
                }
                FindMines(column, row);
                if (didWin())
                {
                    timer.Enabled = false;
                    model.Mine = false;
                    Ending($"Nyertél\nEltelt idő: {timerCounter} mp");
                }
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
            SetText();
        }
    }
}

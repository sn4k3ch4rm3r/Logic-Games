﻿using System;
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
        private Panel panel;
        private Size buttonSize = new Size(170, 60);
        private int padding = 10;
        public MainMenu()
        {
            InitializeComponent();
            CreateButtonPanel();
            this.BackColor = Resources.Colors.Background;
            this.Resize += OnResize;
        }

        private void CreateButtonPanel()
        {
            panel = new Panel();
            panel.Size = new Size(buttonSize.Width, 0);
            panel.Location = new Point(100, 100);
            CreateButton(panel, "2048", game2048_Click);
            CreateButton(panel, "Tetris", gameTetris_Click);
            CreateButton(panel, "Aknakereső", gameMinesweeper_Click);
            CreateButton(panel, "Statisztika", statistics_Click);
            CreateButton(panel, "Adatbázis Beállítások", databaseSettings_Click);
            CenterButtonPanel();
            this.Controls.Add(panel);
        }

        private void CreateButton(Panel panel, string text, EventHandler onClick)
        {
            Resources.CustomButton button = new Resources.CustomButton();
            button.Text = text;
            button.Font = new Font("Arial", 12, FontStyle.Bold);
            button.BackColor = Resources.Colors.ContainterBackground;
            button.ForeColor = Resources.Colors.PrimaryText;
            button.FlatStyle = new FlatStyle();
            button.FlatAppearance.BorderSize = 0;
            button.Click += onClick;
            button.Size = buttonSize;
            panel.Controls.Add(button);
            button.Location = new Point(0, panel.Height);
            panel.Height += buttonSize.Height+padding;
        }

        private void CenterButtonPanel()
        {
            panel.Location = new Point
            (
                (this.ClientRectangle.Width / 2) - (panel.Width / 2),
                (this.ClientRectangle.Height / 2) - (panel.Height / 2)
            );
        }

        private void gameClosed(object sender, FormClosedEventArgs e)
        {
            CreateButtonPanel();
        }

        private void showForm(Form form)
        {
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
            this.Controls[0].Focus();
            form.FormClosed += gameClosed;
        }

        private void game2048_Click(object sender, EventArgs e)
        {
            showForm(new Game2048());
        }

        private void gameTetris_Click(object sender, EventArgs e)
        {
            showForm(new Tetris());
        }

        private void gameMinesweeper_Click(object sender, EventArgs e)
        {
            showForm(new Minesweeper());
        }
        private void statistics_Click(object sender, EventArgs e)
        {
            showForm(new Statistics.Statistics());
        }

        private void databaseSettings_Click(object sender, EventArgs e)
        {
            Form dbSettings = new DatabaseSettingsForm();
            dbSettings.ShowDialog();
        }

        private void OnResize(object sender, EventArgs e)
        {
            CenterButtonPanel();
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            try
            {
                Database.DatabaseHandler.Setup();
            }
            catch
            {
                Form errorForm = new DatabaseUnavailable();
                errorForm.ShowDialog();
                switch(errorForm.DialogResult)
                {
                    case DialogResult.Abort:
                        Environment.Exit(0);
                        break;
                    case DialogResult.Yes:
                        Form dbSettings = new DatabaseSettingsForm();
                        dbSettings.ShowDialog();
                        break;
                }
            }
        }
    }
}

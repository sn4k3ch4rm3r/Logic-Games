
namespace LogicGames
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameTetris = new System.Windows.Forms.Button();
            this.gameMinesweeper = new System.Windows.Forms.Button();
            this.game2048 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameTetris
            // 
            this.gameTetris.Location = new System.Drawing.Point(302, 225);
            this.gameTetris.Name = "gameTetris";
            this.gameTetris.Size = new System.Drawing.Size(122, 45);
            this.gameTetris.TabIndex = 1;
            this.gameTetris.Text = "Tetris";
            this.gameTetris.UseVisualStyleBackColor = true;
            this.gameTetris.Click += new System.EventHandler(this.gameTetris_Click);
            // 
            // gameMinesweeper
            // 
            this.gameMinesweeper.Location = new System.Drawing.Point(302, 276);
            this.gameMinesweeper.Name = "gameMinesweeper";
            this.gameMinesweeper.Size = new System.Drawing.Size(122, 45);
            this.gameMinesweeper.TabIndex = 2;
            this.gameMinesweeper.Text = "Aknakereső";
            this.gameMinesweeper.UseVisualStyleBackColor = true;
            this.gameMinesweeper.Click += new System.EventHandler(this.gameMinesweeper_Click);
            // 
            // game2048
            // 
            this.game2048.Location = new System.Drawing.Point(302, 174);
            this.game2048.Name = "game2048";
            this.game2048.Size = new System.Drawing.Size(122, 45);
            this.game2048.TabIndex = 0;
            this.game2048.Text = "2048";
            this.game2048.UseVisualStyleBackColor = true;
            this.game2048.Click += new System.EventHandler(this.game2048_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 535);
            this.Controls.Add(this.game2048);
            this.Controls.Add(this.gameMinesweeper);
            this.Controls.Add(this.gameTetris);
            this.Name = "MainMenu";
            this.Text = "KANCHO GAMES";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button gameTetris;
        private System.Windows.Forms.Button gameMinesweeper;
        private System.Windows.Forms.Button game2048;
    }
}


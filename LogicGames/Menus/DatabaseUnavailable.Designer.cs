
namespace LogicGames.Menus
{
    partial class DatabaseUnavailable
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
            this.label1 = new System.Windows.Forms.Label();
            this.settings = new LogicGames.Resources.CustomButton();
            this.ignore = new LogicGames.Resources.CustomButton();
            this.exit = new LogicGames.Resources.CustomButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 15F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 59);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hiba történt az adatbázishoz való csatlakozás közben.";
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settings.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.settings.FlatAppearance.BorderSize = 0;
            this.settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.settings.Location = new System.Drawing.Point(284, 86);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(132, 46);
            this.settings.TabIndex = 12;
            this.settings.Text = "Beállítások";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // ignore
            // 
            this.ignore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.ignore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ignore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.ignore.FlatAppearance.BorderSize = 0;
            this.ignore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ignore.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ignore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.ignore.Location = new System.Drawing.Point(146, 86);
            this.ignore.Name = "ignore";
            this.ignore.Size = new System.Drawing.Size(132, 46);
            this.ignore.TabIndex = 11;
            this.ignore.Text = "Folytatás";
            this.ignore.UseVisualStyleBackColor = true;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.exit.Location = new System.Drawing.Point(12, 86);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(128, 46);
            this.exit.TabIndex = 10;
            this.exit.Text = "Kilépés";
            this.exit.UseVisualStyleBackColor = true;
            // 
            // DatabaseUnavailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 133);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.ignore);
            this.Controls.Add(this.exit);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(446, 180);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(446, 180);
            this.Name = "DatabaseUnavailable";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hiba";
            this.ResumeLayout(false);

        }

        #endregion

        private Resources.CustomButton ignore;
        private Resources.CustomButton exit;
        private Resources.CustomButton settings;
        private System.Windows.Forms.Label label1;
    }
}
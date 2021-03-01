
namespace LogicGames.Menus
{
    partial class DatabaseSettingsForm
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
            this.lb_user = new System.Windows.Forms.Label();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.btn_cancel = new LogicGames.Resources.CustomButton();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.lb_password = new System.Windows.Forms.Label();
            this.tbx_database = new System.Windows.Forms.TextBox();
            this.lb_database = new System.Windows.Forms.Label();
            this.tbx_address = new System.Windows.Forms.TextBox();
            this.lb_address = new System.Windows.Forms.Label();
            this.btn_save = new LogicGames.Resources.CustomButton();
            this.SuspendLayout();
            // 
            // lb_user
            // 
            this.lb_user.AutoSize = true;
            this.lb_user.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_user.Location = new System.Drawing.Point(12, 15);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(151, 22);
            this.lb_user.TabIndex = 0;
            this.lb_user.Text = "Felhasználónév: ";
            // 
            // tbx_user
            // 
            this.tbx_user.Font = new System.Drawing.Font("Arial", 10.2F);
            this.tbx_user.Location = new System.Drawing.Point(173, 12);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(252, 27);
            this.tbx_user.TabIndex = 1;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.btn_cancel.Location = new System.Drawing.Point(12, 151);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(196, 46);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Mégse";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // tbx_password
            // 
            this.tbx_password.Font = new System.Drawing.Font("Arial", 10.2F);
            this.tbx_password.Location = new System.Drawing.Point(173, 45);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.PasswordChar = '•';
            this.tbx_password.Size = new System.Drawing.Size(252, 27);
            this.tbx_password.TabIndex = 4;
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_password.Location = new System.Drawing.Point(12, 48);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(70, 22);
            this.lb_password.TabIndex = 3;
            this.lb_password.Text = "Jelszó:";
            // 
            // tbx_database
            // 
            this.tbx_database.Font = new System.Drawing.Font("Arial", 10.2F);
            this.tbx_database.Location = new System.Drawing.Point(173, 78);
            this.tbx_database.Name = "tbx_database";
            this.tbx_database.Size = new System.Drawing.Size(252, 27);
            this.tbx_database.TabIndex = 6;
            // 
            // lb_database
            // 
            this.lb_database.AutoSize = true;
            this.lb_database.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_database.Location = new System.Drawing.Point(12, 81);
            this.lb_database.Name = "lb_database";
            this.lb_database.Size = new System.Drawing.Size(98, 22);
            this.lb_database.TabIndex = 5;
            this.lb_database.Text = "Adatbázis:";
            // 
            // tbx_address
            // 
            this.tbx_address.Font = new System.Drawing.Font("Arial", 10.2F);
            this.tbx_address.Location = new System.Drawing.Point(173, 111);
            this.tbx_address.Name = "tbx_address";
            this.tbx_address.Size = new System.Drawing.Size(252, 27);
            this.tbx_address.TabIndex = 8;
            // 
            // lb_address
            // 
            this.lb_address.AutoSize = true;
            this.lb_address.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_address.Location = new System.Drawing.Point(12, 114);
            this.lb_address.Name = "lb_address";
            this.lb_address.Size = new System.Drawing.Size(128, 22);
            this.lb_address.TabIndex = 7;
            this.lb_address.Text = "Szerver címe:";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
            this.btn_save.Location = new System.Drawing.Point(225, 151);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(200, 46);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Mentés";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // DatabaseSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(437, 203);
            this.Controls.Add(this.tbx_user);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lb_user);
            this.Controls.Add(this.lb_database);
            this.Controls.Add(this.tbx_address);
            this.Controls.Add(this.tbx_password);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.tbx_database);
            this.Controls.Add(this.lb_address);
            this.Controls.Add(this.lb_password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(455, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(455, 250);
            this.Name = "DatabaseSettingsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adatbázis beállítások";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DatabaseSettingsForm_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_user;
        private System.Windows.Forms.TextBox tbx_user;
        private Resources.CustomButton btn_cancel;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.TextBox tbx_database;
        private System.Windows.Forms.Label lb_database;
        private System.Windows.Forms.TextBox tbx_address;
        private System.Windows.Forms.Label lb_address;
        private Resources.CustomButton btn_save;
    }
}
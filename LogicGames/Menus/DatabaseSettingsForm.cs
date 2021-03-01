using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicGames.Database;

namespace LogicGames.Menus
{
    public partial class DatabaseSettingsForm : Form
    {
        public DatabaseSettingsForm()
        {
            InitializeComponent();
            this.BackColor = Resources.Colors.Background;
            foreach (Control control in this.Controls)
            {
                control.ForeColor = Resources.Colors.PrimaryText;
                if(control is TextBox)
                {
                    control.BackColor = Resources.Colors.ContainterBackground;
                    (control as TextBox).BorderStyle = BorderStyle.FixedSingle;
                }
            }
            if (!DatabaseConfigManager.Exists()) DatabaseConfigManager.Create();
            DatabaseConfig config = DatabaseConfigManager.Load();
            tbx_user.Text = config.Username;
            tbx_password.Text = config.Password;
            tbx_database.Text = config.Database;
            tbx_address.Text = config.Address;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void DatabaseSettingsForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Save();
        }

        private void Save()
        {
            DatabaseConfigManager.Save(tbx_user.Text, tbx_password.Text, tbx_database.Text, tbx_address.Text);
            this.Close();
        }
    }
}

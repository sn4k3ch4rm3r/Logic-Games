using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGames.Menus
{
    public partial class DatabaseUnavailable : Form
    {
        public DatabaseUnavailable()
        {
            InitializeComponent();
            this.BackColor = Resources.Colors.Background;
            this.Icon = SystemIcons.Warning;
            label1.ForeColor = Resources.Colors.PrimaryText;
        }
    }
}

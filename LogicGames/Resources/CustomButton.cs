using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGames.Resources
{
    public partial class CustomButton : Button
    {
        public CustomButton()
        {
            InitializeComponent();
            this.BackColor = Resources.Colors.ContainterBackground;
            this.ForeColor = Resources.Colors.PrimaryText;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.SetStyle(ControlStyles.Selectable, false);
        }
    }
}

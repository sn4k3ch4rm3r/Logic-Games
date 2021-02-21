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

namespace LogicGames.Games
{
    public partial class GameView : Form
    {
        protected Rectangle container;
        public GameView()
        {
            InitializeComponent();
            container = new Rectangle(0,0, 500, 600);
        }
    }
}

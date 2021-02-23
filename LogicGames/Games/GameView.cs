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

        private int width = 500;
        private int height = 600;
        public GameView()
        {
            InitializeComponent();
            SetContainerLocation();
            this.Resize += onResize;
        }

        private void onResize(object sender, EventArgs e)
        {
            SetContainerLocation();
            Refresh();
        }
        private void SetContainerLocation()
        {
            container = new Rectangle((ClientRectangle.Width / 2) - (width / 2), (ClientRectangle.Height / 2) - (height / 2), width, height);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGames.Games.Minesweeper
{
    public partial class MinefieldButton : Button
    {
        public MinefieldButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(pevent);
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
            SizeF stringSize = e.Graphics.MeasureString(this.Text, this.Font);
            if (this.Text == "🏴")
                stringSize.Width += 10;
            TextRenderer.DrawText(e.Graphics,this.Text, this.Font, new Point((this.ClientRectangle.Width / 2) - (int)(stringSize.Width / 2), (this.ClientRectangle.Height / 2) - (int)(stringSize.Height / 2)), this.ForeColor, this.BackColor);
        }

        Color bg;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            bg = this.BackColor;
            this.BackColor = Color.FromArgb((int)(BackColor.R / 1.3), (int)(BackColor.G / 1.3), (int)(BackColor.B / 1.3));
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = bg;
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            if (this.Text == "🏴") return;
            if (mevent.Button == MouseButtons.Left)
                bg = this.BackColor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LogicGames.Games.Tetris
{
    class Block
    {
        private SolidBrush color;
        private Pen border;
        public Point Location { get; set; }
        public Size Size { get; set; }

        public Block(int size, Color color, Color border, int borderWidth = 1)
        {
            this.Size = new Size(size, size);
            this.Location = new Point(0, 0);

            this.color = new SolidBrush(color);
            this.border = new Pen(border, borderWidth);
            this.border.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
        }

        public void Render(Graphics g)
        {
            Rectangle rectangle = new Rectangle(this.Location, this.Size);
            g.FillRectangle(color, rectangle);
            g.DrawRectangle(border, rectangle);
        }
    }
}

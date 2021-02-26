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

        private Color sideColor;
        private Color topColor;
        private Color bottomColor;
        private int borderWidth;
        public Point Location { get; set; }
        public Size Size { get; set; }

        public Block(int size, Color color, Color borderSide, Color borderTop, Color borderBottom, int borderWidth = 3)
        {
            this.Size = new Size(size, size);
            this.Location = new Point(0, 0);

            this.color = new SolidBrush(color);

            this.sideColor = borderSide;
            this.topColor = borderTop;
            this.bottomColor = borderBottom;

            this.borderWidth = borderWidth;
        }

        public void Render(Graphics g)
        {
            Rectangle rectangle = new Rectangle(this.Location, this.Size);
            g.FillRectangle(color, rectangle);
            ControlPaint.DrawBorder(g, rectangle,
                sideColor, borderWidth, ButtonBorderStyle.Solid,
                topColor, borderWidth, ButtonBorderStyle.Solid,
                sideColor, borderWidth, ButtonBorderStyle.Solid,
                bottomColor, borderWidth, ButtonBorderStyle.Solid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LogicGames.Games.Game2048
{
    public class Tile
    {
        public int value { get; set; }
        public SolidBrush color;
        public Pen border;
        public int[] Coord { get; set; }
        public Size Size { get; set; }

        public Tile(int size, int value, int[] coord, Color color, Color border)
        {
            this.Size = new Size(size, size);
            this.value = value;
            this.Coord = coord;

            this.color = new SolidBrush(color);
            this.border = new Pen(border, 1);
        }

        public void Render(Graphics g)
        {
            Rectangle rectangle = new Rectangle(Coord[0] * Size.Width, Coord[1] * Size.Height, Size.Width, Size.Height);
            g.DrawRectangle(border, rectangle);
            g.FillRectangle(color, rectangle);
            Font font = new Font(new FontFamily("Arial"), 16, FontStyle.Regular);
            g.DrawString(value.ToString(), font, new SolidBrush(Color.Blue), Coord[0] * Size.Width, Coord[1] * Size.Height);
        }

        public void Move(int dir)
        {
            
            switch (dir)
            {
                //bal
                case 1:
                    this.Coord = new int[] { Coord[0] - 1, Coord[1] };
                    break;
                //jobb
                case 2:
                    this.Coord = new int[] { Coord[0] + 1, Coord[1] };
                    break;
                //fel
                case 3:
                    this.Coord = new int[] { Coord[0], Coord[1] - 1};
                    break;
                //le
                case 4:
                    this.Coord = new int[] { Coord[0], Coord[1] + 1};
                    break;
                default:
                    break;
            }
        }
    }
}

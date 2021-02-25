using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace LogicGames.Games.Game2048
{
    public class Tile
    {
        private Color[] colors = {
            Color.FromArgb(238, 228, 218),
            Color.FromArgb(237, 224, 200),
            Color.FromArgb(242, 177, 121),
            Color.FromArgb(245, 149, 99),
            Color.FromArgb(246, 124, 96),
            Color.FromArgb(249, 94, 59),
            Color.FromArgb(237, 207, 115),
            Color.FromArgb(237, 204, 98),
            Color.FromArgb(237, 200, 80),
            Color.FromArgb(237, 197, 63),
            Color.FromArgb(237, 194, 45),
        };
        public int value { get; set; }
        public int[] Coord { get; set; }
        public Size Size { get; set; }
        PrivateFontCollection pfc = new PrivateFontCollection();
        public Tile(int size, int value, int[] coord)
        {
            int fontLength = Properties.Resources.ClearSans_Bold.Length;
            byte[] fontdata = Properties.Resources.ClearSans_Bold;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            this.Size = new Size(size, size);
            this.value = value;
            this.Coord = coord;
        }

        public void Render(Graphics g)
        {
            Font font = new Font(pfc.Families[0], value < 1000 ? 42 : 32);
            SizeF sizef = g.MeasureString(value.ToString(), font);
            Rectangle rectangle = new Rectangle(Coord[0] * Size.Width, Coord[1] * Size.Height, Size.Width, Size.Height);
            g.FillRectangle(new SolidBrush(value <= 2048 ? colors[(int)Math.Log(value, 2) - 1] : Color.FromArgb(60, 58, 50)), rectangle);
            g.DrawString(value.ToString(), font, new SolidBrush(value < 8 ? Color.Black : Color.White), (Coord[0] * Size.Width) + (Size.Width / 2) - (sizef.Width / 2), (Coord[1] * Size.Height) + (Size.Height / 2) - (sizef.Height / 2));
            
        }
    }
}

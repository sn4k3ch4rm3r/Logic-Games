using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LogicGames.Games.Tetris
{
    static class Shapes
    {
        public struct Shape
        {
            public List<bool[,]> Blocks { get; }
            public Color Color { get; }
            public Color SideColor { get; }
            public Color TopColor { get; }
            public Color BottomColor { get; }

            public Shape(Color color, Color sideColor, Color topColor, Color bottomColor, int[,] shape)
            {
                this.Blocks = new List<bool[,]>();
                this.Color = color;

                SideColor = sideColor;
                TopColor = topColor;
                BottomColor = bottomColor;

                for (int i = 0; i < shape.Length / 4; i++)
                {
                    bool[,] blocks = new bool[4, 4];
                    for (int j = 0; j < 4; j++)
                    {
                        string str = Convert.ToString(shape[i, j], 2).PadLeft(4, '0');
                        bool[] blockPos = str.Select(s => s.Equals('1')).ToArray();
                        for (int x = 0; x < blockPos.Length; x++)
                        {
                            blocks[x, j] = blockPos[x];
                        }
                    }
                    this.Blocks.Add(blocks);
                }
            }
        }
        private static Random rand = new Random();
        public static Shape O = new Shape(
            Color.FromArgb(240,240,1),
            Color.FromArgb(209,210,46),
            Color.FromArgb(255,255,134),
            Color.FromArgb(132,122,0),
            new int[,]
            {
                {
                    0b0000,
                    0b0110,
                    0b0110,
                    0b0000,
                },
            });

        public static Shape I = new Shape(
            Color.FromArgb(1, 240, 241),
            Color.FromArgb(0, 216, 218),
            Color.FromArgb(139, 255, 255),
            Color.FromArgb(0, 124, 126),
            new int[,]
            {
                {
                    0b0000,
                    0b1111,
                    0b0000,
                    0b0000,
                },
                {
                    0b0010,
                    0b0010,
                    0b0010,
                    0b0010,
                },
                {
                    0b0000,
                    0b0000,
                    0b1111,
                    0b0000,
                },
                {
                    0b0100,
                    0b0100,
                    0b0100,
                    0b0100,
                },
            });

        public static Shape J = new Shape(
            Color.FromArgb(239, 160, 0),
            Color.FromArgb(216, 144, 0),
            Color.FromArgb(255, 222, 140),
            Color.FromArgb(127, 80, 0),
            new int[,]
            {
                {
                    0b0000,
                    0b1110,
                    0b0010,
                    0b0000,
                },
                {
                    0b0100,
                    0b0100,
                    0b1100,
                    0b0000,
                },
                {
                    0b1000,
                    0b1110,
                    0b0000,
                    0b0000,
                },
                {
                    0b0110,
                    0b0100,
                    0b0100,
                    0b0000,
                },
            });

        public static Shape L = new Shape(
            Color.FromArgb(1, 1, 240),
            Color.FromArgb(7, 3, 169),
            Color.FromArgb(154, 150, 255),
            Color.FromArgb(0, 0, 120),
            new int[,]
            {
                {
                    0b0000,
                    0b1110,
                    0b1000,
                    0b0000,
                },
                {
                    0b1100,
                    0b0100,
                    0b0100,
                    0b0000,
                },
                {
                    0b0010,
                    0b1110,
                    0b0000,
                    0b0000,
                },
                {
                    0b0100,
                    0b0100,
                    0b0110,
                    0b0000,
                },
            });

        public static Shape T = new Shape(
            Color.FromArgb(160, 0, 241),
            Color.FromArgb(128, 17, 182),
            Color.FromArgb(214, 160, 242),
            Color.FromArgb(80, 0, 118),
            new int[,]
            {
                {
                    0b0000,
                    0b1110,
                    0b0100,
                    0b0000,
                },
                {
                    0b0100,
                    0b1100,
                    0b0100,
                    0b0000,
                },
                {
                    0b0100,
                    0b1110,
                    0b0000,
                    0b0000,
                },
                {
                    0b0100,
                    0b0110,
                    0b0100,
                    0b0000,
                },
            });

        public static Shape Z = new Shape(
            Color.FromArgb(240, 1, 0),
            Color.FromArgb(220, 1, 0),
            Color.FromArgb(237, 161, 162),
            Color.FromArgb(100, 9, 8),
            new int[,]
            {
                {
                    0b1100,
                    0b0110,
                    0b0000,
                    0b0000,
                },
                {
                    0b0010,
                    0b0110,
                    0b0100,
                    0b0000,
                },
                {
                    0b0000,
                    0b1100,
                    0b0110,
                    0b0000,
                },
                {
                    0b0100,
                    0b1100,
                    0b1000,
                    0b0000,
                },
            });

        public static Shape S = new Shape(
            Color.FromArgb(0, 240, 0),
            Color.FromArgb(32, 192, 31),
            Color.FromArgb(167, 244, 166),
            Color.FromArgb(3, 118, 0),
            new int[,]
            {
                {
                    0b0110,
                    0b1100,
                    0b0000,
                    0b0000,
                },
                {
                    0b0100,
                    0b0110,
                    0b0010,
                    0b0000,
                },
                {
                    0b0000,
                    0b0110,
                    0b1100,
                    0b0000,
                },
                {
                    0b1000,
                    0b1100,
                    0b0100,
                    0b0000,
                }
            });

        private static Shape[] shapes = { I, O, T, L, J, S, Z };
        public static Shape Random()
        {
            int index = rand.Next(shapes.Length);
            return shapes[index];
        }
    }
}

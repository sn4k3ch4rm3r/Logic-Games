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
            public Color Border { get; }

            public Shape(Color color, Color border, int[,] shape)
            {
                this.Blocks = new List<bool[,]>();
                this.Color = color;
                this.Border = border;

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
        private static Random rand = new Random(0);
        public static Shape O = new Shape(Color.Yellow, Color.SaddleBrown, new int[,]
            {
                {
                    0b0000,
                    0b0110,
                    0b0110,
                    0b0000,
                },
            });

        public static Shape I = new Shape(Color.Aqua, Color.Blue, new int[,]
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

        public static Shape J = new Shape(Color.Orange, Color.Brown, new int[,]
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

        public static Shape L = new Shape(Color.Blue, Color.DarkBlue, new int[,]
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

        public static Shape T = new Shape(Color.DarkMagenta, Color.Purple, new int[,]
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

        public static Shape Z = new Shape(Color.Red, Color.DarkRed, new int[,]
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

        public static Shape S = new Shape(Color.LimeGreen, Color.Green, new int[,]
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

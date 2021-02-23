using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LogicGames.Games.Tetris
{
    class Tetrimino
    {
        private int stateIndex;
        private List<bool[,]> states;
        
        public Point Location { get; set; }
        
        private int blockSize;
        private Color color;
        private Color border;

        public Tetrimino(int blockSize, Shapes.Shape shape)
        {
            stateIndex = 0;
            this.color = shape.Color;
            this.border = shape.Border;
            this.blockSize = blockSize;

            this.Location = new Point(0, 0);
            int[,] states = shape.Blocks;
            this.states = new List<bool[,]>();
            for (int i = 0; i < states.Length/4; i++)
            {
                bool[,] blocks = new bool[4,4];
                for (int j = 0; j < 4; j++)
                {
                    string str = Convert.ToString(states[i, j], 2).PadLeft(4,'0');
                    bool[] blockPos = str.Select(s => s.Equals('1')).ToArray();
                    for (int x = 0; x < blockPos.Length; x++)
                    {
                        blocks[x, j] = blockPos[x];
                    }
                }
                this.states.Add(blocks);
            }
        }

        public void Move(int direction)
        {
            if(direction == 2)
            {
                stateIndex++;
                if (stateIndex >= states.Count) stateIndex = 0;
            }
            else if(direction == -1 || direction == 1)
            {
                this.Location = new Point(this.Location.X + direction, this.Location.Y);
            }
            else
            {
                this.Location = new Point(this.Location.X, this.Location.Y + 1);
            }
        }

        public void Render(Graphics g)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (states[stateIndex][i, j])
                    {
                        Block b = new Block(blockSize, color, border);
                        b.Location = new Point((this.Location.X + i) * blockSize, (this.Location.Y + j) * blockSize);
                        b.Render(g);
                    }
                }
            }
        }
    }
}

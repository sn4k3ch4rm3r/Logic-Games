using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LogicGames.Games.Tetris
{
    class Board
    {
        private int boardWidth;
        private int boardHeight;
        private int blockSize;

        private Block[,] boardState;

        public int BlockSize { get { return blockSize; } }
        public Size Size { get { return new Size(boardWidth, boardHeight); } }

        public Board(int width, int height, Rectangle container)
        {
            this.boardWidth = width;
            this.boardHeight = height;

            blockSize = (int)((double)container.Height / boardHeight);
            boardState = new Block[width, height];
        }

        public bool IsFilled(int x, int y)
        {
            return boardState[x,y] != null;
        }

        public void SetBlocks(Block[,] blocks)
        {
            for (int j = 0; j < boardHeight; j++)
            {
                for (int i = 0; i < boardWidth; i++)
                {
                    if(blocks[i,j] != null)
                    {
                        boardState[i, j] = blocks[i, j];
                    }
                }
            }
        }

        public void Render(Graphics g)
        {
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    Block b;
                    if (boardState[i,j] == null)
                        b = new Block(blockSize, Color.White, Color.Black);
                    else
                        b = boardState[i, j];
                    b.Location = new Point(i * blockSize, j * blockSize);
                    b.Render(g);
                }
            }
        }
    }
}

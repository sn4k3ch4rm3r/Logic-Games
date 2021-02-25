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
            if (y < 0) return false;
            return boardState[x, y] != null;
        }

        public bool IsLineComplete(int line)
        {
            for (int i = 0; i < boardWidth; i++)
            {
                if (boardState[i, line] == null) return false;
            }
            return true;
        }

        public void MoveDown(int deletedLine)
        {
            for (int y = deletedLine-1; y >= 0; y--)
            {
                for (int x = 0; x < boardWidth; x++)
                {
                    boardState[x, y + 1] = boardState[x, y];
                }
            }
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace LogicGames.Games.Tetris
{
    class Tetrimino
    {
        private Board board;

        private int stateIndex;
        private List<bool[,]> states;
        public bool Moved { get; private set; }

        public Point Location { get; set; }

        private int blockSize;
        private Color color;
        private Color border;

        public Tetrimino(Board board, Shapes.Shape shape)
        {
            this.board = board;
            Moved = false;

            stateIndex = 0;
            this.color = shape.Color;
            this.border = shape.Border;
            this.blockSize = board.BlockSize;

            this.Location = new Point(3, -1);
            this.states = shape.Blocks;   
        }

        public bool Move(int direction)
        {
            bool canMove = false;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (states[stateIndex][i, j])
                    {
                        if (direction == 1)
                        {
                            if (i + this.Location.X + 1 < board.Size.Width && !board.IsFilled(i + this.Location.X + 1, j + this.Location.Y))
                                canMove = true;
                            else return false;
                        }
                        else if (direction == -1)
                        {
                            if (i + this.Location.X - 1 >= 0 && !board.IsFilled(i + this.Location.X - 1, j + this.Location.Y))
                                canMove = true;
                            else return false;
                        }
                        else
                        {
                            if (j + this.Location.Y < board.Size.Height-1 && !board.IsFilled(i + this.Location.X, j + this.Location.Y + 1))
                                canMove = true;
                            else return false;
                        }
                    }
                }
            }
            if (canMove)
            {
                switch (direction)
                {
                    case 0:
                        this.Location = new Point(this.Location.X, this.Location.Y + 1);
                        break;
                    default:    
                        this.Location = new Point(this.Location.X + direction, this.Location.Y);
                        break;
                }
            }
            Moved = true;
            return true;
        }

        public bool Rotate()
        {
            int nextState = stateIndex + 1;
            if (nextState >= states.Count) nextState = 0;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (states[nextState][i, j] &&
                        (i + Location.X >= board.Size.Width
                        || i + Location.X < 0
                        || j + Location.Y >= board.Size.Height
                        || j + Location.Y < 0
                        || board.IsFilled(i+Location.X, j+Location.Y))) return false;
                }
            }
            stateIndex = nextState;
            return true;
        }

        public Block[,] BlocksInBoard
        {
            get
            {
                Block[,] shapeOnBoard = new Block[board.Size.Width, board.Size.Height];
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (states[stateIndex][i,j])
                            shapeOnBoard[Location.X + i, Location.Y + j] = new Block(board.BlockSize, color, border);
                    }
                }
                return shapeOnBoard;
            }
        }

        public void Render(Graphics g)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (states[stateIndex][i, j] && Location.Y+j >= 0)
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

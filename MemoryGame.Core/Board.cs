﻿using System;
using System.Text;

namespace MemoryGame.Core
{
    public class Board<T>
    {
        public int Length { get; }
        public int Width { get; }
        private T[,] Field;
        public T defaultValue { get; }

        public Board(int amountOfCards)
        {
            int pairs = amountOfCards * 2;

            for (int i = (int)Math.Sqrt(pairs); i > 0; i--)
            {
                if (pairs % i == 0)
                {
                    Width = i;
                    Length = pairs / i;
                    break;
                }
            }

            Field = new T[Length, Width];
        }

        public T GetValue(int x, int y)
        {
            return Field[x, y];
        }

        public void SetValue(int x, int y, T value) 
        { 
            Field[x, y] = value;
        }

        public string ToString()
        {
            StringBuilder board = new StringBuilder();

            board.Append("    ");
            for (int j = 0; j < Width; j++)
            {
                board.Append($"{j,3}".PadRight(5));
            }
            board.AppendLine();

            for (int i = 0; i < Length; i++)
            {
                board.Append($"{i,2} |");

                for (int j = 0; j < Width; j++)
                {
                    if (Field[i, j] != null)
                    {
                        board.Append($" {Field[i, j].ToString(),2} ");
                    }
                    else
                    {
                        board.Append(" -- ");
                    }

                    board.Append("|");
                }
                board.AppendLine();
            }

            return board.ToString();
        }



    }
}

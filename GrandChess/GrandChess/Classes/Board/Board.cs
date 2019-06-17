﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess
{
    class Board
    {
        public Square[,] squares;

        public List<Point> CalculatePossibleMoves(Point squarePosition)
        {
            List<Point> possibleMoves = new List<Point>
            {
                new Point(4, 4),
                new Point(4, 5),
                new Point(3, 3),
                new Point(2, 2)
            };
            return possibleMoves;
        }
        public Board()
        {
            squares = new Square[10, 10];
            for (int i = 0; i < 100; i++)
            {
                squares[i/10, i%10] = new Square();
            }
        }
    }
}
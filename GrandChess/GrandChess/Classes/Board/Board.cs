using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GrandChess.Classes.Pieces;

namespace GrandChess
{
    class Board
    {
        public Square[,] squares;

        public List<Point> CalculatePossibleMoves(Point piecePosition)
        {
            Piece movingPiece = squares[piecePosition.Y, piecePosition.X].piece;
            MovementPattern piecePattern = movingPiece.MovePattern(piecePosition);
            List<Point> possibleMoves = new List<Point>();

            foreach (List<Point> slidingPath in piecePattern.slidingPatterns)
            {
                possibleMoves.AddRange(slidingPath);
            }

            foreach (Point jump in piecePattern.jumpPattern)
            {
                possibleMoves.Add(jump);
            }

            foreach (Point move in piecePattern.exceptionPattern)
            {
                possibleMoves.Add(move);
            }

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

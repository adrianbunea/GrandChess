using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class Rook : Piece
    {
        public override MovementPattern MovePattern(Point position)
        {
            MovementPattern pattern = new MovementPattern();
            List<Point> line = new List<Point>();

            //dreapta
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X + i;

                if (newX < 10)
                {
                    line.Add(new Point(newX, position.Y));
                }

                else break;
            }
            pattern.slidingPatterns.Add(line);
            line = new List<Point>();

            //stanga
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X - i;

                if (newX >= 0)
                {
                    line.Add(new Point(newX, position.Y));
                }

                else break;
            }
            pattern.slidingPatterns.Add(line);
            line = new List<Point>();

            //sus
            for (int i = 1; i < 10; i++)
            {
                int newY = position.Y - i;

                if (newY >= 0)
                {
                    line.Add(new Point(position.X, newY));
                }

                else break;
            }
            pattern.slidingPatterns.Add(line);
            line = new List<Point>();

            //jos
            for (int i = 1; i < 10; i++)
            {
                int newY = position.Y + i;

                if (newY < 10)
                {
                    line.Add(new Point(position.X, newY));
                }

                else break;
            }
            pattern.slidingPatterns.Add(line);
            return pattern;
        }

        public Rook(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ? 
                 @"Assets/ChessPieces/WhiteRook.png" : 
                 @"Assets/ChessPieces/BlackRook.png");
        }

    }
}

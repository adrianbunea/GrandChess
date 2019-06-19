using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class Queen : Piece
    {
        public override List<Point> MovePattern(Point position)
        {
            List<Point> pattern = new List<Point>();

            //dreapta
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X + i;

                if (newX < 10)
                {
                    pattern.Add(new Point(newX, position.Y));
                }

                else break;
            }

            //stanga
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X - i;

                if (newX >= 0)
                {
                    pattern.Add(new Point(newX, position.Y));
                }

                else break;
            }

            //sus
            for (int i = 1; i < 10; i++)
            {
                int newY = position.Y - i;

                if (newY >= 0)
                {
                    pattern.Add(new Point(position.X, newY));
                }

                else break;
            }

            //jos
            for (int i = 1; i < 10; i++)
            {
                int newY = position.Y + i;

                if (newY < 10)
                {
                    pattern.Add(new Point(position.X, newY));
                }

                else break;
            }

            for (int i = 1; i < 10; i++)
            {
                int newX = position.X + i;
                int newY = position.Y + i;

                if (newX < 10 && newY < 10)
                {
                    pattern.Add(new Point(newX, newY));
                }

                else break;
            }

            //135 grade
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X - i;
                int newY = position.Y - i;

                if (newX >= 0 && newY >= 0)
                {
                    pattern.Add(new Point(newX, newY));
                }

                else break;
            }

            //-135 grade
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X - i;
                int newY = position.Y + i;

                if (newX >= 0 && newY < 10)
                {
                    pattern.Add(new Point(newX, newY));
                }

                else break;
            }

            //45 grade
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X + i;
                int newY = position.Y - i;

                if (newX < 10 && newY >= 0)
                {
                    pattern.Add(new Point(newX, newY));
                }

                else break;
            }

            return pattern;
        }

        public Queen(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhiteQueen.png" :
                 @"Assets/ChessPieces/BlackQueen.png");
        }

    }
}

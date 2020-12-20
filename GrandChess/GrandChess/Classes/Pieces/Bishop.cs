using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class Bishop : Piece
    {
        public override MovementPattern MovePattern(Point position)
        {
            MovementPattern pattern = new MovementPattern();
            List<Point> diagonal = new List<Point>();

            //-45 grade
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X + i;
                int newY = position.Y + i;

                if (newX < 10 && newY < 10)
                {
                    diagonal.Add(new Point(newX, newY));
                }

                else break;
            }
            pattern.slidingPatterns.Add(diagonal);
            diagonal = new List<Point>();

            //135 grade
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X - i;
                int newY = position.Y - i;

                if (newX >= 0 && newY >= 0)
                {
                    diagonal.Add(new Point(newX, newY));
                }

                else break;
            }
            pattern.slidingPatterns.Add(diagonal);
            diagonal = new List<Point>();

            //-135 grade
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X - i;
                int newY = position.Y + i;

                if (newX >=0 && newY < 10)
                {
                    diagonal.Add(new Point(newX, newY));
                }

                else break;
            }
            pattern.slidingPatterns.Add(diagonal);
            diagonal = new List<Point>();

            //45 grade
            for (int i = 1; i < 10; i++)
            {
                int newX = position.X + i;
                int newY = position.Y - i;

                if (newX < 10 && newY >= 0)
                {
                    diagonal.Add(new Point(newX, newY));
                }

                else break;
            }
            pattern.slidingPatterns.Add(diagonal);

            return pattern;
        }

        public Bishop(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhiteBishop.png" :
                 @"Assets/ChessPieces/BlackBishop.png");
        }
    }
}

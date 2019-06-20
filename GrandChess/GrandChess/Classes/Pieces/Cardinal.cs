using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class Cardinal : Piece
    {
        public override MovementPattern MovePattern(Point position)
        {
            MovementPattern pattern = new MovementPattern();
            int oldX = position.X;
            int oldY = position.Y;
            int newX, newY;

            List<Point> jumps = new List<Point>();
            List<Point> offsets = new List<Point>
            {
                new Point(-1, -2),
                new Point(-2, -1),
                new Point( 1, -2),
                new Point(-2,  1),
                new Point( 1,  2),
                new Point( 2,  1),
                new Point(-1,  2),
                new Point( 2, -1)
            };

            foreach (Point offset in offsets)
            {
                newX = oldX + offset.X;
                newY = oldY + offset.Y;

                if (newX >= 0 && newX < 10 && newY >= 0 && newY < 10)
                {
                    jumps.Add(new Point(newX, newY));
                }
            }
            pattern.jumpPattern = jumps;

            List<Point> diagonal = new List<Point>();

            //-45 grade
            for (int i = 1; i < 10; i++)
            {
                newX = position.X + i;
                newY = position.Y + i;

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
                newX = position.X - i;
                newY = position.Y - i;

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
                newX = position.X - i;
                newY = position.Y + i;

                if (newX >= 0 && newY < 10)
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
                newX = position.X + i;
                newY = position.Y - i;

                if (newX < 10 && newY >= 0)
                {
                    diagonal.Add(new Point(newX, newY));
                }

                else break;
            }
            pattern.slidingPatterns.Add(diagonal);

            return pattern;
        }

        public Cardinal(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhiteCardinal.png" :
                 @"Assets/ChessPieces/BlackCardinal.png");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class Marshall : Piece
    {
        public override MovementPattern MovePattern(Point position)
        {
            MovementPattern pattern = new MovementPattern();
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

            int oldX = position.X;
            int oldY = position.Y;
            int newX, newY;

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

            List<Point> line = new List<Point>();

            //dreapta
            for (int i = 1; i < 10; i++)
            {
                newX = position.X + i;

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
                newX = position.X - i;

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
                newY = position.Y - i;

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
                newY = position.Y + i;

                if (newY < 10)
                {
                    line.Add(new Point(position.X, newY));
                }

                else break;
            }
            pattern.slidingPatterns.Add(line);
            return pattern;
        }

        public Marshall(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhiteMarshall.png" :
                 @"Assets/ChessPieces/BlackMarshall.png");
        }

    }
}

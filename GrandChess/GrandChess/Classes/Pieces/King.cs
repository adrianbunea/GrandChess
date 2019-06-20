using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class King : Piece
    {
        public override MovementPattern MovePattern(Point position)
        {
            int oldX = position.X;
            int oldY = position.Y;
            int newX, newY;

            MovementPattern pattern = new MovementPattern();
            List<Point> offsets = new List<Point>
            {
                new Point(-1, -1),
                new Point(-1,  0),
                new Point(-1,  1),
                new Point( 0, -1),
                new Point( 0,  1),
                new Point( 1, -1),
                new Point( 1,  0),
                new Point( 1,  1)
            };

            foreach (Point offset in offsets)
            {
                newX = oldX + offset.X;
                newY = oldY + offset.Y;

                if (newX >= 0 && newX < 10 && newY >= 0 && newY < 10)
                {
                    pattern.exceptionPattern.Add(new Point(newX, newY));
                }
            }

            return pattern;
        }

        public King(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhiteKing.png" :
                 @"Assets/ChessPieces/BlackKing.png");
        }

    }
}

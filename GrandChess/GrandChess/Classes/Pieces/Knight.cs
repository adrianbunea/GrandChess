using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class Knight : Piece
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

            return pattern;
        }

        public Knight(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhiteKnight.png" :
                 @"Assets/ChessPieces/BlackKnight.png");
        }

    }
}

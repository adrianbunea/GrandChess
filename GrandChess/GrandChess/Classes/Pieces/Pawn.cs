using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class Pawn : Piece
    {
        public override MovementPattern MovePattern(Point position)
        {
            MovementPattern pattern = new MovementPattern();
            int oldY = position.Y;
            int newY;

            if (pieceColor == PieceColor.White)
            {
                newY = oldY - 1;
                if (newY >= 0)
                {
                    pattern.pawnMovePattern.Add(new Point(position.X, newY));
                    pattern.pawnAttackPattern.Add(new Point(position.X-1, newY));
                    pattern.pawnAttackPattern.Add(new Point(position.X+1, newY));
                }

                if (oldY == 7)
                {
                    newY = oldY - 2;
                    pattern.pawnMovePattern.Add(new Point(position.X, newY));
                }
            }

            if (pieceColor == PieceColor.Black)
            {
                newY = oldY + 1;
                if (newY < 10)
                {
                    pattern.pawnMovePattern.Add(new Point(position.X, newY));
                    pattern.pawnAttackPattern.Add(new Point(position.X - 1, newY));
                    pattern.pawnAttackPattern.Add(new Point(position.X + 1, newY));
                }

                if (oldY == 2)
                {
                    newY = oldY + 2;
                    pattern.pawnMovePattern.Add(new Point(position.X, newY));
                }
            }

            return pattern;
        }

        public Pawn(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhitePawn.png" :
                 @"Assets/ChessPieces/BlackPawn.png");
        }
    }
}

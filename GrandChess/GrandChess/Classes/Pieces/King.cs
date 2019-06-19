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
        public override List<Point> MovePattern(Point position)
        {
            return new List<Point>();
        }

        public King(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhiteKing.png" :
                 @"Assets/ChessPieces/BlackKing.png");
        }

    }
}

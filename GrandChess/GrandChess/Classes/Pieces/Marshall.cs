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
        public override List<Point> MovePattern(Point position)
        {
            return new List<Point>();
        }

        public Marshall(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhiteMarshall.png" :
                 @"Assets/ChessPieces/BlackMarshall.png");
        }

    }
}

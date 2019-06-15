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
        protected override List<Point> PossibleMoves()
        {
            return new List<Point>();
        }

        public Bishop(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhiteBishop.png" :
                 @"Assets/ChessPieces/BlackBishop.png");
        }
    }
}

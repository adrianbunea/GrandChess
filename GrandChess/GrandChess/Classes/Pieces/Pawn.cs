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
        protected override List<Point> PossibleMoves()
        {
            return new List<Point>();
        }

        public Pawn(PieceColor pieceColor, Point position) : base(pieceColor, position)
        {
            Image = Image.FromFile(pieceColor == PieceColor.White ?
                 @"Assets/ChessPieces/WhitePawn.png" :
                 @"Assets/ChessPieces/BlackPawn.png");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GrandChess.Classes.Pieces;

namespace GrandChess.Classes
{
    class PieceFactory
    {
        public Piece CreatePiece(string pieceType, Point position)
        {
            switch (pieceType)
            {
                case "br": return new Rook(PieceColor.Black, position);
                case "bkn": return new Knight(PieceColor.Black, position);
                case "bb": return new Bishop(PieceColor.Black, position);
                case "bq": return new Queen(PieceColor.Black, position);
                case "bk": return new King(PieceColor.Black, position);
                case "bm": return new Marshall(PieceColor.Black, position);
                case "bc": return new Cardinal(PieceColor.Black, position);
                case "bp": return new Pawn(PieceColor.Black, position);

                case "wr": return new Rook(PieceColor.White, position);
                case "wkn": return new Knight(PieceColor.White, position);
                case "wb": return new Bishop(PieceColor.White, position);
                case "wq": return new Queen(PieceColor.White, position);
                case "wk": return new King(PieceColor.White, position);
                case "wm": return new Marshall(PieceColor.White, position);
                case "wc": return new Cardinal(PieceColor.White, position);
                case "wp": return new Pawn(PieceColor.White, position);

                default: return null;
            }
        }

    }
}

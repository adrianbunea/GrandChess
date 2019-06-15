using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandChess.Classes.Pieces
{
    class PieceFactory
    {
        Piece CreatePiece(string pieceType)
        {
            switch (pieceType)
            {
                case "br": return new Rook(PieceColor.Black);
                case "bkn": return new Knight(PieceColor.Black);
                case "bb": return new Bishop(PieceColor.Black);
                case "bq": return new Queen(PieceColor.Black);
                case "bk": return new King(PieceColor.Black);
                case "bm": return new Marshall(PieceColor.Black);
                case "bc": return new Cardinal(PieceColor.Black);
                case "bp": return new Pawn(PieceColor.Black);

                case "wr": return new Rook(PieceColor.White);
                case "wkn": return new Knight(PieceColor.White);
                case "wb": return new Bishop(PieceColor.White);
                case "wq": return new Queen(PieceColor.White);
                case "wk": return new King(PieceColor.White);
                case "wm": return new Marshall(PieceColor.White);
                case "wc": return new Cardinal(PieceColor.White);
                case "wp": return new Pawn(PieceColor.White);

                default: return null;
            }
        }

    }
}

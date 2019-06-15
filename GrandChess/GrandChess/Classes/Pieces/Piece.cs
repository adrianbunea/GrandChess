using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

public enum PieceColor
{
    White = 0,
    Black = 1
}

namespace GrandChess
{
    abstract class Piece
    {
        protected Point position;
        protected Image image;
        public PieceColor pieceColor;
        protected abstract List<Point> PossibleMoves();

        public void TryMove(Point destination)
        {
            if (PossibleMoves().Contains(destination))
            {
                Move(destination);
            }
        }
        protected void Move(Point destination)
        {
            position.X = destination.X;
            position.Y = destination.Y;
        }

        public Piece(PieceColor pieceColor)
        {
            this.pieceColor = pieceColor;
        }
    }
}

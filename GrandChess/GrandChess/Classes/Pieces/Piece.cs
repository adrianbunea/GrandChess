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

namespace GrandChess.Classes.Pieces
{
    abstract class Piece
    {
        public PieceColor pieceColor;
        protected Point position;
        public Image Image { get; protected set; }

        //public void TryMove(Point destination)
        //{
        //    if (PossibleMoves().Contains(destination))
        //    {
        //        Move(destination);
        //    }
        //}
        //protected void Move(Point destination)
        //{
        //    position.X = destination.X;
        //    position.Y = destination.Y;
        //}

        public abstract  MovementPattern MovePattern(Point position);

        public Piece(PieceColor pieceColor, Point position)
        {
            this.pieceColor = pieceColor;
            this.position = position;
        }
    }
}

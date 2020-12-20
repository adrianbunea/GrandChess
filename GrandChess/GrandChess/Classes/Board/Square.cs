using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GrandChess.Classes.Pieces;

namespace GrandChess
{
    class Square
    {
        public Color backgroundColor;
        public bool available;
        public Piece piece;

        public Square(Piece piece)
        {
            this.piece = piece;
        }

        public Square()
        {
            piece = null;
        }
    }
}

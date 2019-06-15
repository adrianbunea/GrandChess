using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
    }
}

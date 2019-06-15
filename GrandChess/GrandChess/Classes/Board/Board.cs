using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandChess
{
    class Board
    {
        public Square[,] squares;

        public Board()
        {
            squares = new Square[10, 10];
        }
    }
}

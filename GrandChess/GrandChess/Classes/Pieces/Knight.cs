﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class Knight : Piece
    {
        protected override List<Point> PossibleMoves()
        {
            return new List<Point>();
        }

        public Knight(PieceColor pieceColor) : base(pieceColor)
        {

        }

    }
}

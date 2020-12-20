using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrandChess.Classes.Pieces
{
    class MovementPattern
    {
        public List<List<Point>> slidingPatterns;
        public List<Point> jumpPattern;
        public List<Point> kingPattern;
        public List<Point> pawnMovePattern;
        public List<Point> pawnAttackPattern;

        public MovementPattern()
        {
            slidingPatterns = new List<List<Point>>();
            jumpPattern = new List<Point>();
            kingPattern = new List<Point>();
            pawnMovePattern = new List<Point>();
            pawnAttackPattern = new List<Point>();
        }
    }
}

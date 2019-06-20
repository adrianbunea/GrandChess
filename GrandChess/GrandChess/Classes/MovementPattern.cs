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
        public List<Point> exceptionPattern;

        public MovementPattern()
        {
            slidingPatterns = new List<List<Point>>();
            jumpPattern = new List<Point>();
            exceptionPattern = new List<Point>();
        }
    }
}

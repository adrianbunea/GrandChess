using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GrandChess.Classes.Pieces;

namespace GrandChess
{
    class Board
    {
        public Square[,] squares;

        public List<Point> CalculatePossibleMoves(Point piecePosition)
        {
            Piece movingPiece = squares[piecePosition.Y, piecePosition.X].piece;
            MovementPattern piecePattern = movingPiece.MovePattern(piecePosition);
            List<Point> possibleMoves = new List<Point>();

            foreach (List<Point> slidingPath in piecePattern.slidingPatterns)
            {
                foreach (Point move in slidingPath)
                {
                    if (squares[move.Y, move.X].piece != null)
                    {
                        if (squares[move.Y, move.X].piece.pieceColor == movingPiece.pieceColor)
                        {
                            break;
                        }

                        if (squares[move.Y, move.X].piece != null)
                        {
                            possibleMoves.Add(move);
                            break;
                        }
                    }
                    possibleMoves.Add(move);
                }
            }

            foreach (Point jump in piecePattern.jumpPattern)
            {
                if (squares[jump.Y, jump.X].piece == null || movingPiece.pieceColor != squares[jump.Y, jump.X].piece.pieceColor)
                {
                    possibleMoves.Add(jump);
                }
            }

            if (movingPiece.GetType() == typeof(King))
            {
                for (int i = 0; i < piecePattern.kingPattern.Count; i++)
                {
                    Point move = piecePattern.kingPattern[i];
                    if (squares[move.Y, move.X].piece != null && squares[move.Y, move.X].piece.pieceColor == movingPiece.pieceColor)
                    {
                        piecePattern.kingPattern.RemoveAt(i);
                        i--;
                    }
                }

                List<Point> enemyPieceCoordinates = new List<Point>();
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        if (squares[y, x].piece != null && squares[y, x].piece.pieceColor != movingPiece.pieceColor)
                        {
                            enemyPieceCoordinates.Add(new Point(x, y));
                        }
                    }
                }

                List<Point> dangerousSquares = new List<Point>();
                foreach (Point enemyPieceCoordinate in enemyPieceCoordinates)
                {
                    if (squares[enemyPieceCoordinate.Y, enemyPieceCoordinate.X].piece.GetType() == typeof(King))
                    {
                        dangerousSquares.AddRange(squares[enemyPieceCoordinate.Y, enemyPieceCoordinate.X].piece.MovePattern(enemyPieceCoordinate).kingPattern);
                    }

                    else if (squares[enemyPieceCoordinate.Y, enemyPieceCoordinate.X].piece.GetType() == typeof(Pawn))
                    {
                        List<Point> pawnMoves = new List<Point>();
                        pawnMoves = squares[enemyPieceCoordinate.Y, enemyPieceCoordinate.X].piece.MovePattern(enemyPieceCoordinate).pawnAttackPattern;
                        dangerousSquares.AddRange(pawnMoves);
                    }

                    else
                    {
                        dangerousSquares.AddRange(CalculatePossibleMoves(enemyPieceCoordinate));
                    }
                }

                foreach (Point move in piecePattern.kingPattern)
                {
                    if (!dangerousSquares.Contains(move))
                    {
                        possibleMoves.Add(move);
                    }
                }
            }

            if (movingPiece.GetType() == typeof(Pawn))
            {
                foreach (Point move in piecePattern.pawnMovePattern)
                {
                    if (squares[move.Y, move.X].piece == null)
                    {
                        possibleMoves.Add(move);
                    }
                }

                foreach (Point move in piecePattern.pawnAttackPattern)
                {
                    if (squares[move.Y, move.X].piece != null && movingPiece.pieceColor != squares[move.Y, move.X].piece.pieceColor)
                    {
                        possibleMoves.Add(move);
                    }
                }
            } 

            return possibleMoves;
        }
        public Board()
        {
            squares = new Square[10, 10];
            for (int i = 0; i < 100; i++)
            {
                squares[i/10, i%10] = new Square();
            }
        }
    }
}

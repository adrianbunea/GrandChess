using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrandChess.Classes;

namespace GrandChess
{
    public partial class MainWindow : Form
    {
        Board board;

        int originSquare = -1;
        int destinationSquare = -1;

        readonly Color POSSIBLE_DESTINATION_COLOR = Color.PaleGreen;
        readonly Color SELECTED_PIECE_COLOR = Color.Crimson;
        readonly Color WHITE_COLOR = Color.White;
        readonly Color BLACK_COLOR = Color.DimGray;

        List<Point> possibleMoves;

        public MainWindow()
        {
            InitializeComponent();
            CreateBoard();
        }

        private void CreateBoard()
        {
            board = new Board();
            int squareSize = chessBoardPanel.Size.Height / 10;
            for (int i = 0; i < 100; i++)
            {
                PictureBox square = CreateSquare(squareSize, i);
                chessBoardPanel.Controls.Add(square);
            }
        }

        private void NewGame(object sender, EventArgs e)
        {
            ResetColors();
            originSquare = -1;
            List<string> piecesCodifications = ReadInitialSetup();
            PieceFactory pieceFactory = new PieceFactory();
            board = new Board();

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    string pieceCodification = piecesCodifications[y * 10 + x];
                    Point position = new Point(x, y);
                    board.squares[y, x] = new Square(pieceFactory.CreatePiece(pieceCodification, position));

                    if (board.squares[y, x].piece != null)
                    {
                        ((PictureBox)chessBoardPanel.Controls[y * 10 + x]).Image = board.squares[y, x].piece.Image;
                    }
                }
            }
        }

        private PictureBox CreateSquare(int squareSize, int i)
        {
            int row = i / 10;
            int column = i % 10;

            PictureBox square = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(squareSize, squareSize),
                BackColor = ((row + column) % 2 == 0 ? WHITE_COLOR : BLACK_COLOR),
                Location = new Point(column * squareSize, row * squareSize),
            };
            square.Click += SquareClick;
            return square;
        }

        private void SquareClick(object sender, EventArgs e)
        {
            PictureBox squarePictureBox = sender as PictureBox;
            int pictureBoxIndex = chessBoardPanel.Controls.IndexOf(squarePictureBox);
            Point squarePosition = XYPosition(pictureBoxIndex);

            Square clickedSquare = board.squares[squarePosition.Y, squarePosition.X];
            
            if (originSquare < 0 && clickedSquare.piece != null)
            {
                originSquare = pictureBoxIndex;
                chessBoardPanel.Controls[pictureBoxIndex].BackColor = SELECTED_PIECE_COLOR;
                possibleMoves = board.CalculatePossibleMoves(squarePosition);
                foreach (Point possibleMove in possibleMoves)
                {
                    chessBoardPanel.Controls[possibleMove.X + possibleMove.Y * 10].BackColor = POSSIBLE_DESTINATION_COLOR;
                }
            }

            else
            {
                destinationSquare = pictureBoxIndex;
                if (originSquare >= 0)
                {
                    if (possibleMoves.Contains(squarePosition) && destinationSquare != originSquare)
                    {
                        Piece selectedPiece = board.squares[XYPosition(originSquare).Y, XYPosition(originSquare).X].piece;
                        board.squares[XYPosition(originSquare).Y, XYPosition(originSquare).X].piece = null;

                        board.squares[squarePosition.Y, squarePosition.X].piece = selectedPiece;
                        ((PictureBox)chessBoardPanel.Controls[destinationSquare]).Image = selectedPiece.Image;
                        ((PictureBox)chessBoardPanel.Controls[originSquare]).Image = null;
                        originSquare = -1;
                        destinationSquare = -1;
                        ResetColors();
                    }
                    else
                    {
                        ResetColors();
                        originSquare = -1;
                        destinationSquare = -1;
                    }
                }
            }
        }

        private void ResetColors()
        {
            for (int i = 0; i < 100; i++)
            {
                int row = i / 10;
                int column = i % 10;
                chessBoardPanel.Controls[i].BackColor = ((row + column) % 2 == 0 ? WHITE_COLOR : BLACK_COLOR);
            }
        }

        private Point XYPosition(int index)
        {
            int x = index % 10;
            int y = index / 10;
            return new Point(x, y);
        }

        private static List<string> ReadInitialSetup()
        {
            string[] rows = File.ReadAllLines(@"../../Assets/InitialSetup.txt");
            List<string> pieces = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                pieces.AddRange(rows[i].Split(','));
            }

            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i] = pieces[i].Trim();
            }

            return pieces;
        }
    }
}

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

        public MainWindow()
        {
            InitializeComponent();
            CreateBoard();
        }

        private void CreateBoard()
        {
            int squareSize = chessBoardPanel.Size.Height / 10;
            for (int i = 0; i < 100; i++)
            {
                PictureBox square = CreateSquare(squareSize, i);
                chessBoardPanel.Controls.Add(square);
            }
        }

        private void NewGame(object sender, EventArgs e)
        {
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
                    //board.squares[i, j].piece.image = Image.FromFile(piecePaths[key]);
                }
            }

            //foreach (PictureBox square in chessBoardPanel.Controls)
            //{
            //    string key = piecesCodifications[chessBoardPanel.Controls.IndexOf(square)];
            //    if (key != "0")
            //    {
            //        square.Image = Image.FromFile(piecePaths[key]);
            //    }
            //}
        }

        private static PictureBox CreateSquare(int squareSize, int i)
        {
            int row = i / 10;
            int column = i % 10;

            PictureBox square = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(squareSize, squareSize),
                BackColor = ((row + column) % 2 == 0 ? Color.White : Color.DimGray),
                Location = new Point(column * squareSize, row * squareSize)
            };
            return square;
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

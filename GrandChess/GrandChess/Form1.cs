﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrandChess
{
    public partial class mainWindow : Form
    {
        readonly Dictionary<string, string> piecePaths = new Dictionary<string, string>
        {
            {"br" , @"Assets/ChessPieces/BlackRook.png"},
            {"bkn", @"Assets/ChessPieces/BlackKnight.png"},
            {"bb" , @"Assets/ChessPieces/BlackBishop.png"},
            {"bq" , @"Assets/ChessPieces/BlackQueen.png"},
            {"bk" , @"Assets/ChessPieces/BlackKing.png"},
            {"bm" , @"Assets/ChessPieces/BlackMarshall.png"},
            {"bc" , @"Assets/ChessPieces/BlackCardinal.png"},
            {"bp" , @"Assets/ChessPieces/BlackPawn.png"},
            {"wr" , @"Assets/ChessPieces/WhiteRook.png"},
            {"wkn", @"Assets/ChessPieces/WhiteKnight.png"},
            {"wb" , @"Assets/ChessPieces/WhiteBishop.png"},
            {"wq" , @"Assets/ChessPieces/WhiteQueen.png"},
            {"wk" , @"Assets/ChessPieces/WhiteKing.png"},
            {"wm" , @"Assets/ChessPieces/WhiteMarshall.png"},
            {"wc" , @"Assets/ChessPieces/WhiteCardinal.png"},
            {"wp" , @"Assets/ChessPieces/WhitePawn.png"}
        };
        public mainWindow()
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

            //List<Piece> pieces = new List<Piece>();
            Board board = new Board();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string key = piecesCodifications[i * 10 + j];
                    if (key != "0")
                    {
                        //board.squares[i, j].piece = new Pawn();
                        //board.squares[i, j].piece.image = Image.FromFile(piecePaths[key]);
                    }
                }
            }

            foreach (PictureBox square in chessBoardPanel.Controls)
            {
                string key = piecesCodifications[chessBoardPanel.Controls.IndexOf(square)];
                if (key != "0")
                {
                    square.Image = Image.FromFile(piecePaths[key]);
                }
            }
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

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

        private void NewGame(object sender, EventArgs e)
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

            foreach (PictureBox square in chessBoardPanel.Controls)
            {
                string key = pieces[chessBoardPanel.Controls.IndexOf(square)];
                if (key != "0")
                {
                    square.Image = Image.FromFile(piecePaths[key]);
                }
            }
        }
    }
}

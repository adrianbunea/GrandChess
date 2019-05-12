using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrandChess
{
    public partial class mainWindow : Form
    {
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
                int row = i / 10;
                int column = i % 10;

                PictureBox square = new PictureBox()
                {
                    //Image = Image.FromFile(@"Assets/ChessPieces/BlackBishop.png"),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(squareSize, squareSize),
                    BackColor = ((row + column) % 2 == 0 ? Color.White : Color.DimGray),
                    Location = new Point(column * squareSize, row * squareSize)
                };

                chessBoardPanel.Controls.Add(square);
            }
        }

        private void NewGame(object sender, EventArgs e)
        {
        }
    }
}

using System;
using System.Windows.Forms;

namespace TicTacToeAI
{
    public partial class BoardWindow : Form
    {
        public BoardWindow()
        {
            var Board = new Board();
            var AIX = new AI(Board, 0.9, 0.5, 'X');
            var AIO = new AI(Board, 0.95, 0.6, 'O');
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

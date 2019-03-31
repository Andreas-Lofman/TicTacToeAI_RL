using System;
using System.Windows.Forms;

namespace TicTacToeAI
{
    public partial class BoardWindow : Form
    {
        public Label IterationLabel;
        public Button[] TileButtons;
        private Board Board;
        private AI AIX;
        private AI AIO;
        
        bool CancelLearning;
        bool WaitForPlayer;
        bool EndGame;
        int PlayCount = 1;

        public BoardWindow()
        {
            Board = new Board();
            AIX = new AI(Board, 0.9, 1, Board.Symbols[1]);
            AIO = new AI(Board, 0.9, 1, Board.Symbols[2]);
            InitializeComponent();
            IterationLabel = label3;
            TileButtons = new Button[]{ button_1, button_2, button_3, button_4, button_5, button_6, button_7, button_8, button_9 };
            var nl = Environment.NewLine;
            ExitLabel.Text = "(You need to press " + nl + "this to be able to exit," + nl + " sorry!)";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Button button in TileButtons)
                button.Visible = false;

            label3.Visible = true;
            CancelButton.Visible = true;
            AnnouncerLabel.Visible = false;
            button1.Text = "Play with AI";
            EndGameButton.Visible = false;
            ExitLabel.Visible = false;
            Learn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EndGame = false;
            Board.ResetBoard();
            AnnouncerLabel.Visible = false;
            foreach( Button button in TileButtons )
            {
                button.Visible = true;
                button.Text = "";
            }
            label3.Visible = false;
            CancelButton.Visible = false;
            EndGameButton.Visible = true;
            ExitLabel.Visible = true;           
            button1.Text = "Reset Board";
            Play();
        }

        private void Play()
        {          
            var isEnded = false;
            int time = 1;
            while (!EndGame)
            {
                var action = AIX.PerformActionFromState(time);
                TileButtons[action].Text = Board.Symbols[1].ToString();
                isEnded = Board.CheckForWinner(AIX.Symbol) || Board.IsDraw() || EndGame;
                if (isEnded)
                    break;

                WaitForPlayer = true;
                while (WaitForPlayer)
                {
                    System.Threading.Thread.Sleep(500);
                    Application.DoEvents();
                }               
                isEnded = Board.CheckForWinner('O') || Board.IsDraw() || EndGame;
                if (isEnded)
                    break;
                time++;
                Application.DoEvents();
            }
            if (EndGame)
                return;
            PlayCount++;

            //Zero reward for loosing/draw, only change if any AI won
            var AIReward = 0;
            AnnouncerLabel.Visible = true;
            if (Board.CheckForWinner(AIX.Symbol))
            {
                AnnouncerLabel.Text = "AI won!";
                AIReward = 1;
            }
            if (Board.CheckForWinner('O'))
            {
                AnnouncerLabel.Text = "Player won!";
                AIReward = -1;
            }
            if (Board.IsDraw())
                AnnouncerLabel.Text = "Draw!";

            AIX.UpdateQTable(AIReward, PlayCount, true);
            AIX.SaveQTableToFile();
        }

        private void Learn()
        {
            var isEnded = false;
            int Episodes = 1000000;
            //Zero reward for loosing/draw, only change if any AI won
            var AIXReward = 0;
            var AIOReward = 0;
            CancelLearning = false;
            for (int i = 1; i <= Episodes; i++)
            {
                if (CancelLearning)
                    break;
                int time = 1;               
                while (true)
                {
                    AIX.PerformActionFromState(time);
                    isEnded = Board.CheckForWinner(AIX.Symbol) || Board.IsDraw();
                    if (isEnded)
                        break;

                    AIO.PerformActionFromState(time);
                    isEnded = Board.CheckForWinner(AIO.Symbol) || Board.IsDraw();
                    if (isEnded)
                        break;
                    time++;
                }

                if (Board.CheckForWinner(AIX.Symbol))
                {
                    AIXReward = 1;
                    AIOReward = -1;
                }
                if (Board.CheckForWinner(AIO.Symbol))
                {
                    AIOReward = 1;
                    AIXReward = -1;
                }
                else
                {
                    AIOReward = 0;
                    AIXReward = 0;
                }
                AIX.UpdateQTable(AIXReward, i, true);
                AIO.UpdateQTable(AIOReward, i, true);

                if (i % 1000 == 0)
                {
                    AIX.SaveQTableToFile();
                    AIO.SaveQTableToFile();
                    label2.Text = "Running "+ i + " out of " + Episodes + " episodes.";
                    label2.Show();
                }
                Board.ResetBoard();
                Application.DoEvents();
            }
            AIX.SaveQTableToFile();
            AIO.SaveQTableToFile();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelLearning = true;
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (button_1.Text == "")
            {
                button_1.Text = Board.Symbols[2].ToString();
                Board.SetTile(0, Board.Symbols[2]);
                WaitForPlayer = false;
            }
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (button_2.Text == "")
            {
                button_2.Text = Board.Symbols[2].ToString();
                Board.SetTile(1, Board.Symbols[2]);
                WaitForPlayer = false;
            }
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (button_3.Text == "")
            {
                button_3.Text = Board.Symbols[2].ToString();
                Board.SetTile(2, Board.Symbols[2]);
                WaitForPlayer = false;
            }
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (button_4.Text == "")
            {
                button_4.Text = Board.Symbols[2].ToString();
                Board.SetTile(3, Board.Symbols[2]);
                WaitForPlayer = false;
            }
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            if (button_5.Text == "")
            {
                button_5.Text = Board.Symbols[2].ToString();
                Board.SetTile(4, Board.Symbols[2]);
                WaitForPlayer = false;
            }
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            if (button_6.Text == "")
            {
                button_6.Text = Board.Symbols[2].ToString();
                Board.SetTile(5, Board.Symbols[2]);
                WaitForPlayer = false;
            }
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            if (button_7.Text == "")
            {
                button_7.Text = Board.Symbols[2].ToString();
                Board.SetTile(6, Board.Symbols[2]);
                WaitForPlayer = false;
            }
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            if (button_8.Text == "")
            {
                button_8.Text = Board.Symbols[2].ToString();
                Board.SetTile(7, Board.Symbols[2]);
                WaitForPlayer = false;
            }
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            if (button_9.Text == string.Empty)
            {
                button_9.Text = Board.Symbols[2].ToString();
                Board.SetTile(8, Board.Symbols[2]);
                WaitForPlayer = false;
            }
        }

        private void EndGameButton_Click(object sender, EventArgs e)
        {
            EndGame = true;
            WaitForPlayer = false;
        }

        //Unused functions (removing them will cause project to not build)

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BoardWindow_Load(object sender, EventArgs e)
        {

        }

        private void AnnouncerLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

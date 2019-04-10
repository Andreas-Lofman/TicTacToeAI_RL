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
            AIX = new AI(Board, 0.95, 1, Board.Symbols[1]);
            AIO = new AI(Board, 0.95, 1, Board.Symbols[2]);
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
            label2.Visible = true;
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
            label2.Visible = false;
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
                AIReward = 10;
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
            int InitEpisodes = 10000000;
            //Zero reward for loosing/draw, only change if any AI won
            var AIXReward = 0;
            var AIOReward = 0;
            CancelLearning = false;
            var AIs = new AI[]{AIX, AIO};
            var AIRewards = new int[] { 0, 0 };
            int Iterations = 20;
            //TODO: Implement learning such that one AI is fixed for n episodes while 
            //the other is learning, then fix that one and learn the other -> Fix AI into environment.
            //Reset Q-table before each learning-episode to erase previous optimal behaviour
            //(the behaviour vs a random-pick AI is not optimal for a learned AI)
            int AIIndex;
            for (int k = 0; k < Iterations; k++)
            {
                //0 or 1, X or O, the other is frozen
                AIIndex = k % 2;
                //Reset AI, start learning each opponent from scratch
                AIs[AIIndex].ResetValues();
                //Give every AI increasingly more iterations to "catch up" to already learned opponent
                var Episodes = InitEpisodes * (k + 1);
                int i = 1;
                for (; i <= Episodes; i++)
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
                        AIRewards[0] = 1;
                        AIRewards[1] = -1;
                    }
                    if (Board.CheckForWinner(AIO.Symbol))
                    {
                        AIRewards[0] = -1;
                        AIRewards[1] = 1;
                    }
                    else
                    {
                        AIRewards[0] = 0;
                        AIRewards[1] = 0;
                    }
                    AIs[AIIndex].UpdateQTable(AIRewards[AIIndex], i, true);

                    if (i % 1000 == 0)
                    {
                        AIs[AIIndex].SaveQTableToFile();
                        label2.Text = "Running " + i + " out of " + Episodes + " episodes.";
                        label2.Show();
                    }
                    Board.ResetBoard();
                    Application.DoEvents();
                }
                AIs[AIIndex].SaveQTableToFile();
            }
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

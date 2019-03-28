using System;
using System.Runtime.InteropServices;

namespace TicTacToeAI
{
    class Program
    {       
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            bool UseGUI = false;

            if (UseGUI)
            { 
                // Hide
                var Handle = GetConsoleWindow();
                ShowWindow(Handle, SW_HIDE);

                var Window = new BoardWindow();

                Window.ShowDialog();
            }
            else
            {
                Console.WriteLine("Do you want to \"play\" or \"learn\" the AI?");
                var answer = Console.ReadLine();
                if (answer.ToLower() == "learn")
                    Learn();
                else if (answer.ToLower() == "play")
                        Play();
                else
                    Console.WriteLine("Invalid option, good job stupid.");
                Console.ReadKey();

            }
        }

        static void Learn()
        {
            var Board = new Board();
            var AIX = new AI(Board, 0.9, 1, Board.Symbols[1]);
            var AIO = new AI(Board, 0.9, 1, Board.Symbols[2]);

            var isEnded = false;
            int Episodes = 10000000;
            //Zero reward for loosing/draw, only change if any AI won
            var AIXReward = 0;
            var AIOReward = 0;
            for (int i = 1; i <= Episodes; i++)
            {
                while (true)
                {
                    AIX.PerformActionFromState();
                    isEnded = Board.CheckForWinner(AIX.Symbol) || Board.IsDraw();
                    if (isEnded)
                        break;
  
                    AIO.PerformActionFromState();
                    isEnded = Board.CheckForWinner(AIO.Symbol) || Board.IsDraw();
                    if (isEnded)
                        break;
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
                    Console.WriteLine(i + " out of " + Episodes + " run");
                }
                Board.ResetBoard();
            }
            AIX.SaveQTableToFile();
            AIO.SaveQTableToFile();
            Console.ReadKey();
        }

        static void Play()
        {
            var Board = new Board();
            var AIX = new AI(Board, 0.95, 0, Board.Symbols[1]);
            for (int k = 1; k < 100; k++)
            {
                var isEnded = false;
                while (true)
                {
                    AIX.PerformActionFromState();
                    Board.WriteBoard();
                    isEnded = Board.CheckForWinner(AIX.Symbol) || Board.IsDraw();
                    if (isEnded)
                        break;

                    Console.WriteLine("Insert number 1-9 to add your symbol");
                    var action = Console.ReadLine();
                    Board.SetTile(int.Parse(action) - 1, 'O');
                    Board.WriteBoard();
                    isEnded = Board.CheckForWinner('O') || Board.IsDraw();
                    if (isEnded)
                        break;
                }
                //Zero reward for loosing/draw, only change if any AI won
                var AIReward = 0;
                if (Board.CheckForWinner(AIX.Symbol))
                {
                    Console.WriteLine("The AI (" + AIX.Symbol + ") won!");
                    AIReward = 1;
                }
                if (Board.CheckForWinner('O'))
                {
                    Console.WriteLine("The Player (O) won!");
                    AIReward = -1;
                }

                AIX.UpdateQTable(AIReward, k, true);
                AIX.SaveQTableToFile();
                Board.ResetBoard();
            }
        }       
    }
}

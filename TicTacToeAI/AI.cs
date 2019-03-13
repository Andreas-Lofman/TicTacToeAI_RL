using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TicTacToeAI
{
    class AI
    {
        int NStates;
        Board Board;
        double[,] QTable;
        int[] StateCounters;
        char Symbol;
        const string FileName = "QTable.txt";
        const string NFileName = "Iterations.txt";
        string FilePath;
        string NFilePath;
        List<int> VisitedStates;
        List<int> PerformedActions;
        double eps;
        double DiscountFactor;

        public AI(Board _board, double discount, double Eps, char Symb)
        {
            FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\"+FileName;
            NFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + NFileName;
            Board = _board;
            NStates = Board.LayoutToState.Count;
            Symbol = Symb;
            QTable = new double[NStates,9];
            StateCounters = new int[NStates];
            VisitedStates = new List<int>();
            PerformedActions = new List<int>();
            ReadFromFile();
            eps = Eps;
            DiscountFactor = discount;
        }

        public void UpdateQTable(int Return, int k, bool ChangeEps)
        {
            if(ChangeEps)
                eps = 1 / k;
            for(int i = VisitedStates.Count - 1; i >= 0; i--)
            {
                var Discount = Math.Pow(DiscountFactor, i - (VisitedStates.Count - 1));
                var state = VisitedStates[i];
                var action = PerformedActions[i];
                var N = StateCounters[state]++;
                QTable[state, action] += 1/N * (Discount * Return - QTable[state, action]);
            }
            SaveQTableToFile();
            VisitedStates.Clear();
            PerformedActions.Clear();
        }
        
        public void PerformActionFromState()
        {
            var state = Board.GetCurrentStateIndex();                    
            int action=0;
            double prevMax=QTable[state,0];
            
            for(int i = 1; i < QTable.GetLength(1); i++)          
                if (QTable[state, i] > prevMax)
                    action = i;           

            Random rand = new Random();
            var randomAction = rand.Next(0, 8);
            if (rand.NextDouble() < eps)
                action = randomAction;
            var result = Board.SetTile(action, Symbol);
            //Invalid move, recursive retry
            if (!result)
                PerformActionFromState();
            else
            {
                VisitedStates.Add(state);
                PerformedActions.Add(action);
                Board.WriteBoard();
            }          
        }


        private void ReadFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("The Q-Table file in location "+FilePath+" could not be found, creating file based on current Q-table.");
                SaveQTableToFile();    
            }
            else
            {
                try
                {
                    string[] lines = File.ReadAllLines(FilePath);
                    for (int k = 0; k < NStates; k++)
                    {
                        var values = lines[k].Split(';');
                        for (int i = 0; i < 9; i++)
                            QTable[k, i] = double.Parse(values[i]);
                    }
                    lines = File.ReadAllLines(NFilePath);
                    for(int k = 0; k < NStates; k++)                    
                        StateCounters[k] = int.Parse(lines[k]);                       
                    

                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception occured while reading file and the Q-table could thus not be read.");
                    Console.WriteLine("The exception message is: "+ ex.Message);
                }
            }
        }

        private void SaveQTableToFile()
        {
            List<string> TableToWrite = new List<string>();
            try
            {               
                for (int k = 0; k < QTable.GetLength(0); k++)
                {
                    StringBuilder line = new StringBuilder();
                    for (int i = 0; i < QTable.GetLength(1); i++)
                        line.Append(QTable[k, i].ToString()).Append(";");
                    TableToWrite.Add(line.ToString().TrimEnd(';'));
                }
                File.WriteAllLines(FilePath, TableToWrite.ToArray());

                TableToWrite.Clear();
                for (int k = 0; k < NStates; k++)
                {
                    var value = StateCounters[k].ToString();
                    TableToWrite.Add(value);
                }
                File.WriteAllLines(NFilePath, TableToWrite.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured while writing to file and the Q-table could thus not be saved.");
                Console.WriteLine("The exception message is: " + ex.Message);
            }
        }
    }   

        
}

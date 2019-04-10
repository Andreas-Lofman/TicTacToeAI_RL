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
        int[,] StateCounters;
        public char Symbol;
        const string FileName = "QTable";
        const string NFileName = "Iterations";
        string FilePath;
        string NFilePath;
        List<int> VisitedStates;
        List<int> PerformedActions;
        double initEps;
        double eps;
        double DiscountFactor;
        static Random RandomGenerator = new Random();
        float LearningRate = 0.1f;

        public AI(Board _board, double discount, double Eps, char Symb)
        {
            FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\"+FileName+Symb+".txt";
            NFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + NFileName+Symb + ".txt";
            Board = _board;
            NStates = Board.LayoutToState.Count;
            Symbol = Symb;
            QTable = new double[NStates,9];
            StateCounters = new int[NStates,9];
            //Initialize optimistic Q-values (Maximal reward of 1)
            for (int k = 0; k < QTable.GetLength(0); k++)
                for (int i = 0; i < QTable.GetLength(1); i++)
                {
                    QTable[k, i] = 1;
                    StateCounters[k, i] = 1;
                }
            VisitedStates = new List<int>();
            PerformedActions = new List<int>();
            ReadFromFile();
            eps = Eps;
            initEps = Eps;
            DiscountFactor = discount;
        }

        public void UpdateQTable(int Return, int k, bool ChangeEps = true)
        {
            if(ChangeEps)
                eps = 1 / k;
            for(int i = VisitedStates.Count - 1; i >= 0; i--)
            {
                var Discount = Math.Pow(DiscountFactor, (VisitedStates.Count - 1) - i);
                var state = VisitedStates[i];
                var action = PerformedActions[i];
                var N = ++StateCounters[state, action];
                //Using UCB1 upper-bound Q-value: 
                QTable[state, action] += LearningRate/N * (Discount * Return - QTable[state, action]);
            }
            //SaveQTableToFile();
            VisitedStates.Clear();
            PerformedActions.Clear();
        }
        
        public int PerformActionFromState(int k)
        {
            var state = Board.GetCurrentStateIndex();                               
            var availableActions = Board.GetAvailableSlots();
            int action = availableActions[0];
            double QprevMax = QTable[state, action];
            double UCB = Math.Sqrt(2 * Math.Log(k) / StateCounters[state, action]);
            double prevMax = QprevMax + UCB;
            double UCBi = 0;
            double QVali = 0;

            for (int i = 1; i < availableActions.Count; i++)
            {
                if (QTable[state, availableActions[i]] + Math.Sqrt(2 * Math.Log(k) / StateCounters[state, availableActions[i]]) > prevMax)
                    action = availableActions[i];
            }

            //var randomIndex = RandomGenerator.Next(availableActions.Count);
            //var randomAction = availableActions[randomIndex];
            //if (RandomGenerator.NextDouble() < eps)
            //    action = randomAction;
            Board.SetTile(action, Symbol);          
            VisitedStates.Add(state);
            PerformedActions.Add(action);
            return action;
        }

        public void ResetValues()
        {
            QTable.Initialize();
            StateCounters.Initialize();
            eps = initEps;
        }

        private void ReadFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("The Q-Table file in location "+FilePath+" could not be found, creating new file from zero-valued Q-table.");
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
                    for (int k = 0; k < NStates; k++)
                    {
                        var values = lines[k].Split(';');
                        for (int i = 0; i < 9; i++)
                            StateCounters[k, i] = int.Parse(values[i]);
                    }                      
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception occured while reading file and the Q-table could thus not be read.");
                    Console.WriteLine("The exception message is: "+ ex.Message);
                }
            }
        }

        public void SaveQTableToFile()
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
                for (int k = 0; k < StateCounters.GetLength(0); k++)
                {
                    StringBuilder line = new StringBuilder();
                    for (int i = 0; i < StateCounters.GetLength(1); i++)
                        line.Append(StateCounters[k, i].ToString()).Append(";");
                    TableToWrite.Add(line.ToString().TrimEnd(';'));
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

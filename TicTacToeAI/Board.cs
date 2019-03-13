using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeAI
{
    class Board
    {
        //Tiles of the board. Each slot can be occupied by a player-character
        public char[] Tiles = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        public char[] Symbols = {' ','X','O'};
        public const char AISymbol = 'X';
        //Dictionary containing a translation between layout-string and state-index in table
        //No need to include states where it's the player's turn, the AI cannot perform any actions in these cases
        public Dictionary<string, int> LayoutToState = new Dictionary<string, int>();
        //First state: Empty field and it's the AI:s turn        
        
        public Board()
        {
            //Fill the dictionary with state-identifiers
            int[] SymbolCounters = {0,0,0,0,0,0,0,0,0};
            int StateCounter = 0;
            string StateKey;
           
            //Add first full empty-state from the start
            StateKey = string.Join("", Tiles);
            LayoutToState.Add(StateKey, StateCounter++);
            while (!string.Join("", Tiles).Equals("OOOOOOOOO"))
            {
                //Create Next State 
                SymbolCounters[0] = SymbolCounters[0]==2 ? 0 : SymbolCounters[0] + 1;
                Tiles[0] = Symbols[SymbolCounters[0]];
                for (int k = 1; k < SymbolCounters.Length; k++)
                {
                    if (SymbolCounters[k - 1] != 0)
                        break;
                    SymbolCounters[k] = SymbolCounters[k] == 2 ? 0 : SymbolCounters[k] + 1;
                    Tiles[k] = Symbols[SymbolCounters[k]];                    
                }

                //Add State to dictionary
                StateKey = string.Join("", Tiles);
                LayoutToState.Add(StateKey, StateCounter++);
            }

            //Trim the dictionary to remove unusable states 
            //(Where count(X) and count(O) differs by more than 1) 
            int i = 0;
            int n;
            n = LayoutToState.Count;
            while (i < n)
            {
                var Key = LayoutToState.ElementAt(i).Key;
                var CountO = Key.Count(c => c == 'O');
                var CountX = Key.Count(c => c == 'X');

                if (CountO - CountX < -1 || CountO - CountX > 1)
                    LayoutToState.Remove(Key);
                else
                    i++;
                n = LayoutToState.Count;            
            }
            
            //Reset indexes to account for removed gaps
            for(n = 0; n < LayoutToState.Count; n++)
            {
                var Key = LayoutToState.ElementAt(n).Key;
                LayoutToState[Key] = n;
            }

            ResetBoard();          
        }
        
        public bool SetTile(int Position, char Symbol)
        {
            if (Tiles[Position] != ' ')
                return false;
            Tiles[Position] = Symbol;
            return true;
        }

        public void ResetBoard()
        {
            for (int k = 0; k < Tiles.Length; k++)
                Tiles[k] = ' ';
        }

        public int GetCurrentStateIndex()
        {
            return LayoutToState[string.Join("", Tiles)];
        }

        public void WriteBoard()
        {
            Console.WriteLine("------");
            Console.WriteLine("|" + Tiles[0] + "|" + Tiles[1] + "|" + Tiles[2] + "|");
            Console.WriteLine("------");
            Console.WriteLine("|" + Tiles[3] + "|" + Tiles[4] + "|" + Tiles[5] + "|");
            Console.WriteLine("------");
            Console.WriteLine("|" + Tiles[6] + "|" + Tiles[7] + "|" + Tiles[8] + "|");
            Console.WriteLine("------");
        }
    }
}

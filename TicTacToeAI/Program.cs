using System;
using System.Collections.Generic;

namespace TicTacToeAI
{
    class Program
    {        
        static void Main(string[] args)
        {
            var Board = new Board();
            var AIO = new AI(Board, 0.9, 0.5, 'O');
            var AIX = new AI(Board, 0.95, 0.6, 'X');
            Board.WriteBoard();
            AIO.PerformActionFromState();
            AIX.PerformActionFromState();
            AIO.PerformActionFromState();
            Console.ReadKey();
        }
    }
}

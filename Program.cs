using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {

        static char[] board = new char[10];

        /// <summary>
        /// Displays the board.
        /// </summary>
        static void DisplayBoard()
        {
            Console.WriteLine("    "+board[1] + "|" + board[2] + "|" + board[3]);
            Console.WriteLine("   -------");
            Console.WriteLine("    " + board[4] + "|" + board[5] + "|" + board[6]);
            Console.WriteLine("   -------");
            Console.WriteLine("    " + board[7] + "|" + board[8] + "|" + board[9]);
        }


        /// <summary>
        /// Starts the game.
        /// </summary>
        static void StartGame()
        {
            for (int i = 1; i < 10; i++)
                board[i] = ' ';

            Console.WriteLine("New Game Started");
            DisplayBoard();
        }

        static void Main(string[] args)
        {
            StartGame();

            //Temp ReadLine to view Console
            Console.ReadLine();
        }
    }
}

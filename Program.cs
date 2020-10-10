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
        static char playerChoice;
        static char compChoice;


        /// <summary>
        /// Player chooses a character.
        /// </summary>
        static void SelectCharacter()
        {
            Console.Write("Enter your Character: ");
            string selection = Console.ReadLine();

            if (selection == "X" || selection == "x" )
            {
                playerChoice = char.Parse(selection.ToUpper());
                compChoice = 'O';
            }
            else if(selection == "O" || selection == "o")
            {
                playerChoice = char.Parse(selection.ToUpper());
                compChoice = 'X';
            }
            else
                Console.WriteLine("Invalid Input");
        }

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
            SelectCharacter();

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

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
        static void UC2SelectCharacter()
        {
            Console.Write("Enter your Character: ");
            string selection = Console.ReadLine();

            if (selection == "X" || selection == "x")
            {
                playerChoice = char.Parse(selection.ToUpper());
                compChoice = 'O';
            }
            else if (selection == "O" || selection == "o")
            {
                playerChoice = char.Parse(selection.ToUpper());
                compChoice = 'X';
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.Read();         //To read the output in console
                System.Environment.Exit(-1);
            }
        }

        /// <summary>
        /// Displays the board.
        /// </summary>
        static void UC3_ShowBoard()
        {
            Console.WriteLine("    "+board[1] + "|" + board[2] + "|" + board[3]);
            Console.WriteLine("   -------");
            Console.WriteLine("    " + board[4] + "|" + board[5] + "|" + board[6]);
            Console.WriteLine("   -------");
            Console.WriteLine("    " + board[7] + "|" + board[8] + "|" + board[9]);
        }

        static void UC4_MakeMove()
        {
            Console.Write("Enter the position you want to Mark: ");
            bool flag = true;
            while (flag)
            {
                int pos = int.Parse(Console.ReadLine());
                if (pos > 0 && pos < 10)
                {
                    if (board[pos] != ' ')
                        Console.WriteLine("Position is not free");
                    else
                    {
                        board[pos] = playerChoice;
                        flag = false;
                    }
                }
                else
                    Console.WriteLine("Invalid Input");
            }
}


        /// <summary>
        /// Starts the game.
        /// </summary>
        static void UC1_StartGame()
        {
            for (int i = 1; i < 10; i++)
                board[i] = ' ';

            Console.WriteLine("New Game Started");
            UC2SelectCharacter();

            UC3_ShowBoard();

            UC4_MakeMove();

            UC3_ShowBoard();
        }

        static void Main(string[] args)
        {
            UC1_StartGame();

            //Temp ReadLine to view Console
            Console.ReadLine();
        }
    }
}

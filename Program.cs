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

        enum Turn
        {
            Player=1,
            Computer=2
        }


        static void Main(string[] args)
        {
            UC1_StartGame();

            //Temp ReadLine to view Console
            Console.ReadLine();
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

            UC4_MakeMove(UC6_CoinToss());

            UC3_ShowBoard();
        }

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

        /// <summary>
        /// Complete a Turn.
        /// </summary>
        /// <param name="turn">Turn is of the player or Computer</param>
        static void UC4_MakeMove(Turn turn)
        {
            if (turn == Turn.Player)
            {
                Console.Write("Enter the position you want to Mark: ");
                bool flag = true;
                while (flag)
                {
                    try
                    {
                        int pos = int.Parse(Console.ReadLine());
                        if (pos > 0 && pos < 10)
                        {
                            if (board[pos] != ' ')
                                Console.WriteLine("Position is not free");
                            else
                            {
                                if (turn == Turn.Player)
                                    board[pos] = playerChoice;
                                else
                                    board[pos] = compChoice;
                                flag = false;
                            }
                        }
                        else
                            Console.WriteLine("Invalid Input");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
                board[new Random().Next(1, 10)] = compChoice;
        }
        
        /// <summary>
        /// Toss the coin to select first Player
        /// </summary>
        /// <returns></returns>
        static Turn UC6_CoinToss()
        {
            string choice;
            while (true)
            {
                Console.Write("Select 1.Heads 2.Tails : ");
                choice = Console.ReadLine();
                if (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Invalid Input");
                }
                else
                    break;
            }

            int toss = new Random().Next(1, 3);
            if (toss == 1)
                Console.Write("Coin landed as Heads. ");
            else
                Console.Write("Coin landed as Tails. ");

            if (toss == int.Parse(choice))
            {
                Console.WriteLine("You win the Toss, You start first");
                return Turn.Player;
            }
            else
            {
                Console.WriteLine("Computer wins the Toss, Computer starts first");
                return Turn.Computer;
            }
        }


    }
}

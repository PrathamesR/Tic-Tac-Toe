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
            Player = 1,
            Computer = 2,
            GameOver
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

            UC3_ShowBoard(board);
            Turn turn = UC6_CoinToss();
            while (turn != Turn.GameOver)
            {
                UC4_MakeMove(turn);
                UC3_ShowBoard(board);
                Console.WriteLine();
                turn = UC7_GetNextTurn(turn);
            }
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
        static void UC3_ShowBoard(char []boardName)
        {
            Console.WriteLine("    " + boardName[1] + "|" + boardName[2] + "|" + boardName[3]);
            Console.WriteLine("   -------");
            Console.WriteLine("    " + boardName[4] + "|" + boardName[5] + "|" + boardName[6]);
            Console.WriteLine("   -------");
            Console.WriteLine("    " + boardName[7] + "|" + boardName[8] + "|" + boardName[9]);
        }

        /// <summary>
        /// Complete a Turn.
        /// </summary>
        /// <param name="turn">Turn is of the player or Computer</param>
        static void UC4_MakeMove(Turn turn)
        {
            if (turn == Turn.Player)
            {
                Console.WriteLine("Your Turn");
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
            {
                Console.WriteLine("Computer's Turn");
                UC8_ComputersMove();
            }
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


        /// <summary>
        /// Compute the next turn or if the match has ended.
        /// </summary>
        /// <param name="turn">The turn.</param>
        /// <returns></returns>
        static Turn UC7_GetNextTurn(Turn turn)
        {

            if (UC8_CheckWinningCondition(board))
            {
                if (turn == Turn.Computer)
                    Console.WriteLine("Computer Wins");
                else if (turn == Turn.Player)
                    Console.WriteLine("You win!!");

                return Turn.GameOver;
            }

            bool movesLeft = false;
            foreach (char i in board)
                if (i == ' ')
                    movesLeft = true;

            if (!movesLeft)
            {
                Console.WriteLine("Its a Tie!!");
                return Turn.GameOver;
            }

            if (turn == Turn.Computer)
                return Turn.Player;

            if (turn == Turn.Player)
                return Turn.Computer;

            //Code Never reaches here
            return Turn.GameOver;
        }


        /// <summary>
        /// Checks if someone is winning.
        /// </summary>
        /// <param name="boardName">Name of the board.</param>
        /// <param name="turn">The turn.</param>
        /// <returns></returns>
        static bool UC8_CheckWinningCondition(char []boardName)
        {
            if ((boardName[1] == boardName[2] && boardName[2] == boardName[3] && boardName[1] != ' ')
                   || (boardName[4] == boardName[5] && boardName[5] == boardName[6] && boardName[4] != ' ')
                   || (boardName[7] == boardName[8] && boardName[8] == boardName[9] && boardName[7] != ' ')
                   || (boardName[1] == boardName[4] && boardName[4] == boardName[7] && boardName[1] != ' ')
                   || (boardName[2] == boardName[5] && boardName[5] == boardName[8] && boardName[2] != ' ')
                   || (boardName[3] == boardName[6] && boardName[6] == boardName[9] && boardName[3] != ' ')
                   || (boardName[1] == boardName[5] && boardName[5] == boardName[9] && boardName[1] != ' ')
                   || (boardName[3] == boardName[5] && boardName[5] == boardName[7] && boardName[3] != ' '))            
                return true;
            else
                return false;
        }

        /// <summary>
        /// Computers Turn.
        /// </summary>
        static void UC8_ComputersMove()
        {
            bool ifGoodMove = false;

            if (UC8_CheckIfWinning())
            {
                ifGoodMove = true;
                return;
            }
            if (UC9_BlockOpponent())
            {
                ifGoodMove = true;
                return;
            }
            if (UC10_TakeCorners())
            {
                ifGoodMove = true;
                return;
            }

            if(UC11_TakeRest())
            {
                ifGoodMove = true;
                return;
            }

            if (!ifGoodMove)
            {
                Console.WriteLine("Error in code");
                return;
            }
        }

        /// <summary>
        /// Checks if Computer has a winning play.
        /// </summary>
        /// <returns></returns>
        static bool UC8_CheckIfWinning()
        {
            char[] tempBoard = new char[10];
            for (int i = 1; i < board.Length; i++)
            {
                if (board[i] == ' ')
                {
                    board.CopyTo(tempBoard, 0);
                    tempBoard[i] = compChoice;
                    if (UC8_CheckWinningCondition(tempBoard))
                    {
                        board[i] = compChoice;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks and blocks player if he can win.
        /// </summary>
        /// <returns></returns>
        static bool UC9_BlockOpponent()
        {
            char[] tempBoard = new char[10];
            for (int i = 1; i < board.Length; i++)
            {
                if (board[i] == ' ')
                {
                    board.CopyTo(tempBoard, 0);
                    tempBoard[i] = playerChoice;
                    if (UC8_CheckWinningCondition(tempBoard))
                    {
                        Console.WriteLine("sdf");
                        board[i] = compChoice;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if Computer can place in corner.
        /// </summary>
        /// <returns></returns>
        static bool UC10_TakeCorners()
        {
            int[] pos = new int[4] { 1, 3, 7, 9 };
            foreach (int i in pos)
            {
                if (board[i] == ' ')
                {
                    board[i] = compChoice;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Places in rest of the remaining spaces.
        /// </summary>
        /// <returns></returns>
        static bool UC11_TakeRest()
        {
            if(board[5]==' ')
            {
                board[5] = compChoice;
                return true;
            }
            else
            {
                int[] pos = new int[4] { 2, 6, 4, 8 };
                foreach(int i in pos)
                {
                    if(board[i]==' ')
                    {
                        board[i] = compChoice;
                        return true;
                    }
                }
                return false;
            }
        }
    }
}

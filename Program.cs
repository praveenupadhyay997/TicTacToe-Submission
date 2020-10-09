using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Linq;
using System.Threading;

namespace TicTacToeGame
{
    class Program
    {
        public static char[] board = new char[10];
        public static char playerMove, computerMove;
        /// <summary>
        /// To give the player a choice to choose his symbol
        /// </summary>
        public static void chooseOptions()
        {
            Console.WriteLine("Enter your Choice user X or O=");
            char userChoice = Convert.ToChar(Console.ReadLine().ToUpper());
            TicTacToeGame.ChoiceInGame(userChoice);
        }

        /// <summary>
        /// Function to Replicate the entire move starting from the getting position from user
        /// </summary>
        /// <param name="chance"></param>
        /// <returns></returns>
        public static int CompleteMove(int chance)
        {
            if (chance == 1)
            {
                Console.WriteLine("\n\n==============Player Turn=================");
                TicTacToeGame.ShowBoardInGame(board);
                int userMove = TicTacToeGame.getUserMove(board);
                if (userMove == 3)
                    board[TicTacToeGame.movePosition] = playerMove;
                else if ( userMove== 1)
                {
                    Console.WriteLine("You have already occupied this position");
                    return 1;
                }
                else if (userMove == 2)
                {
                    Console.WriteLine("Computer has already occupied this position");
                    return 1;
                }
            }
            else
            {
                Console.WriteLine("\n\n==============Computer Turn=================");
                TicTacToeGame.ShowBoardInGame(board);
                int userMove = TicTacToeGame.getUserMove(board);
                if (userMove == 3)
                    board[TicTacToeGame.movePosition] = computerMove;
                else if (userMove == 1)
                {
                    Console.WriteLine("You have already occupied this position");
                    return 1;
                }
                else if (userMove == 2)
                {
                    Console.WriteLine("Computer has already occupied this position");
                    return 1;
                }
                else if(userMove==0)
                    Console.WriteLine("Ineligible Index Position");    
            }
            return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe Game");
            int count = 0;
            board = TicTacToeGame.AssignBoard();
            chooseOptions();

            playerMove = TicTacToeGame.playerChoice;
            computerMove = TicTacToeGame.computerChoice;

            int chance = TicTacToeGame.TossFeature();
            char flagForMatchStatus = 'n';
            while(flagForMatchStatus == 'n' && count <9)
            {
                if (chance == 1)
                {
                    int flag = CompleteMove(chance);
                    if (flag == 1)
                    {
                        Console.WriteLine("Please make a move in the blanks");
                    }
                    else
                    {
                        chance = 2;
                    }
                }
                else
                {
                    int flag = CompleteMove(chance);
                    if (flag == 1)
                    {
                        Console.WriteLine("Please make a move in the blanks");
                    }
                    else
                    {
                        chance = 1;
                    }
                }
                flagForMatchStatus = TicTacToeGame.CheckForGameStatus(board);
                TicTacToeGame.DeclarationInGame(flagForMatchStatus, count);
                count++;
            }
        }
    }
}

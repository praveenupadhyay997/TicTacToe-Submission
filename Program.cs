using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Linq;

namespace TicTacToeGame
{
    class Program
    {
        public static char[] board = new char[10];
        public static int[] index = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static char playerMove, computerMove;
        public static void chooseOptions()
        {
            Console.WriteLine("Enter your Choice user X or O=");
            char userChoice = Convert.ToChar(Console.ReadLine().ToUpper());
            TicTacToeGame.ChoiceInGame(userChoice);
        }

        public static int getUserMove(char[] board)
        {
            Console.WriteLine("Enter your move");
            int movePosition = Convert.ToInt32(Console.ReadLine());
            if (board[movePosition] == ' ')
                return movePosition;
            else
                return 0;
        }

        public static int CompleteMove(int chance)
        {
            if (chance == 1)
            {
                TicTacToeGame.ShowBoardInGame(board);
                int userMove = getUserMove(board);
                if (index.Contains(userMove))
                {
                    Console.WriteLine("Eligible move");
                }

                int historyPositionStatus = TicTacToeGame.AlreadyOccupied(board, userMove);
                if (historyPositionStatus == 3)
                    board[userMove] = playerMove;
                else if (historyPositionStatus == 1)
                {
                    Console.WriteLine("You have already occupied this position");
                    return 1;
                }
                else if (historyPositionStatus == 2)
                {
                    Console.WriteLine("Computer has already occupied this position");
                    return 1;
                }
            }
            else
            {
                TicTacToeGame.ShowBoardInGame(board);
                int userMove = getUserMove(board);
                if (index.Contains(userMove))
                {
                    Console.WriteLine("Eligible move");
                }

                int historyPositionStatus = TicTacToeGame.AlreadyOccupied(board, userMove);
                if (historyPositionStatus == 3)
                    board[userMove] = computerMove;
                else if (historyPositionStatus == 1)
                {
                    Console.WriteLine("You have already occupied this position");
                    return 1;
                }
                else if (historyPositionStatus == 2)
                {
                    Console.WriteLine("Computer has already occupied this position");
                    return 1;
                }
            }
            return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe Game");

            board = TicTacToeGame.AssignBoard();
            chooseOptions();

            playerMove = TicTacToeGame.playerChoice;
            computerMove = TicTacToeGame.computerChoice;

            int chance = TicTacToeGame.TossFeature();
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
                    TicTacToeGame.ShowBoardInGame(board);
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
                    chance = 2;
                    TicTacToeGame.ShowBoardInGame(board);
                }
            }



        }
    }
}

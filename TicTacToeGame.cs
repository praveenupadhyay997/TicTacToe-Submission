using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToeGame
    {
        public static char[] board = new char[10];
        public const char FIRST_CHOICE = 'X';
        public const char SECOND_CHOICE = 'O';
        public static char playerChoice;
        public static char computerChoice;
        public static int[] index = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static int movePosition;

        public static char[] AssignBoard()
        {
            for(int i=0; i<board.Length;i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        /// <summary>
        /// Choices the in game.
        /// </summary>
        /// <param name="choice">The choice.</param>
        public static void ChoiceInGame(char choice)
        {
            if (choice == 'X')
            {
                playerChoice = FIRST_CHOICE;
                computerChoice = SECOND_CHOICE;
            }
            else
            {
                playerChoice = SECOND_CHOICE;
                computerChoice = FIRST_CHOICE;
            }
            Console.WriteLine("Choice of Player is {0} and computer is {1}", playerChoice, computerChoice);
        }
        /// <summary>
        /// Updates the board.
        /// </summary>
        /// <param name="updateBoard">The update board.</param>
        public static void UpdateBoard(char [] updateBoard)
        {
            for(int i=1;i<board.Length;i++)
            {
                board[i] = updateBoard[i];
            }
        }
        /// <summary>
        /// Shows the board in game.
        /// </summary>
        /// <param name="board">The board.</param>
        public static void ShowBoardInGame(char[] board)
        {
            UpdateBoard(board);
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }
        public static int getUserMove(char[] board,int chance)
        {
            Random random = new Random();
            if (chance == 2)
            {
                movePosition = random.Next(1, 10);
                int playerWinning = TicTacToeGame.GetWinnersMove(board);
                if (index.Contains(playerWinning))
                {
                    Console.WriteLine("Player Is About to Win. Go To Block it");
                    movePosition = playerWinning;
                }
            }
            else
            {
                Console.WriteLine("Enter your move");
                movePosition = Convert.ToInt32(Console.ReadLine());
            }
            
            if (index.Contains(movePosition))
            {
                if (board[movePosition] == playerChoice)
                    return 1;
                else if (board[movePosition] == computerChoice)
                    return 2;
                else if (board[movePosition] == ' ')
                    return 3;
            }
                return 0;
        }
        /// <summary>
        /// Tosses the feature.
        /// </summary>
        /// <returns></returns>
        public static int TossFeature()
        {
            int chance;
            Random random = new Random();
            Console.WriteLine("Player Call Head - 0 or Tail - 1");
            int tossCall = Convert.ToInt32(Console.ReadLine());
            int tossVar = random.Next(0, 2);
            if (tossVar == tossCall)
            {
                Console.WriteLine("Player Won the toss");
                chance = 1;
            }
            else
            {
                Console.WriteLine("Computer Won the toss");
                chance = 2;
            }
            return chance;
        }
        /// <summary>
        /// Checks for game status.
        /// </summary>
        /// <param name="gameBoard">The game board.</param>
        /// <returns></returns>
        public static char CheckForGameStatus(char[] gameBoard)
        {
            UpdateBoard(gameBoard);
            // For the Horizontal Position Win
            if (board[1] == board[2] && board[2] == board[3])
            {
                if(board[1]!=' ')
                return board[1];
            }
            else if (board[4] == board[5] && board[5] == board[6])
            {
                if (board[4] != ' ')
                    return board[4];
            }
            else if (board[6] == board[7] && board[7] == board[8])
            {
                if (board[6] != ' ')
                    return board[6];
            }

            // For Vertical Position Win
            else if (board[1] == board[4] && board[4] == board[7])
            {
                if (board[1] != ' ')
                    return board[1];
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                if (board[2] != ' ')
                    return board[2];
            }
            else if (board[3] == board[6] && board[6] == board[9])
            {
                if (board[3] != ' ')
                    return board[3];
            }

            //Check For Diagonal Position Win
            else if (board[1] == board[5] && board[5] == board[9])
            {
                if (board[1] != ' ')
                    return board[1];
            }
            else if (board[3] == board[5] && board[5] == board[7])
            {
                if (board[3] != ' ')
                    return board[3];
            }
            return 'n';
        }
        /// <summary>
        /// Declarations for Status of the game.
        /// </summary>
        /// <param name="flagForStatus">The flag for status.</param>
        /// <param name="noOfTurns">The no of turns.</param>
        public static void DeclarationInGame(char flagForStatus, int noOfTurns)
        {
            if (flagForStatus == computerChoice)
            {
                Console.Clear();
                ShowBoardInGame(board);
                Console.WriteLine("============Computer Has Won the Game============");
            }
            else if (flagForStatus == playerChoice)
            {
                Console.Clear();
                ShowBoardInGame(board);
                Console.WriteLine("============Player Has Won the Game============");
            }
            else if (flagForStatus == 'n' && noOfTurns == 9)
            {
                Console.Clear();
                Console.WriteLine("============Game Has Tied============");
                Console.ReadKey();
                Environment.Exit(0);
            } 
        }

        public static int GetWinnersMove(char[] board)
        {
            int[] horizontalTracing = { 1, 4, 7 };
            int[] verticalTracing = { 1, 2, 3 };
            int[] diagonalTracing = { 1, 3 };
            foreach (int i in horizontalTracing) 
            {
                if (board[i] == board[i + 1] && board[i] == playerChoice && board[i+2] == ' ')
                    return i + 2;
                else if (board[i] == board[i + 2] && board[i] == playerChoice && board[i + 1] == ' ')
                    return i + 1;
                else if (board[i+2] == board[i + 1] && board[i+2] == playerChoice && board[i] == ' ')
                    return i ;
            }
            foreach(int i in verticalTracing)
            {
                if (board[i] == board[i + 3] && board[i] == playerChoice && board[i + 6] == ' ')
                    return i + 6;
                else if (board[i] == board[i + 6] && board[i] == playerChoice && board[i + 3] == ' ')
                    return i + 3;
                else if (board[i + 3] == board[i + 6] && board[i + 3] == playerChoice && board[i] == ' ')
                    return i;
            }
            foreach(int i in diagonalTracing)
            {
                if(i==1)
                {
                    if (board[i] == board[i + 4] && board[i] == playerChoice && board[i + 8] == ' ')
                        return i + 8;
                    else if (board[i] == board[i + 8] && board[i] == playerChoice && board[i + 4] == ' ')
                        return i + 4;
                    else if (board[i + 4] == board[i + 8] && board[i + 4] == playerChoice && board[i] == ' ')
                        return i;
                }
                else
                {
                    if (board[i] == board[i + 2] && board[i] == playerChoice && board[i + 4] == ' ')
                        return i + 4;
                    else if (board[i] == board[i + 4] && board[i] == playerChoice && board[i + 2] == ' ')
                        return i + 2;
                    else if (board[i + 2] == board[i + 4] && board[i + 2] == playerChoice && board[i] == ' ')
                        return i;
                }
            }
            return 0;
        }

    }
}

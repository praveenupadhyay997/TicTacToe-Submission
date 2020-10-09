using System;
using System.Collections.Generic;
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

        public static char[] AssignBoard()
        {
            for(int i=0; i<board.Length;i++)
            {
                board[i] = ' ';
            }
            return board;
        }

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

        public static void UpdateBoard(char [] updateBoard)
        {
            for(int i=1;i<board.Length;i++)
            {
                board[i] = updateBoard[i];
            }
        }
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

        public static int AlreadyOccupied(char[] board, int position)
        {
            if (board[position] == playerChoice)
                return 1;
            else if (board[position] == computerChoice)
                return 2;
            else if (board[position] == ' ')
                return 3;
            else
                return 0;
        }
        
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

        public static void DeclarationInGame(char flagForStatus, int noOfTurns)
        {
            if (flagForStatus == computerChoice)
            {
                Console.Clear();
                Console.WriteLine("============Computer Has Won the Game============");
            }
            else if (flagForStatus == playerChoice)
            {
                Console.Clear();
                Console.WriteLine("============Player Has Won the Game============");
            }
            else if (flagForStatus == 'n' && noOfTurns == 9)
            {
                Console.Clear();
                Console.WriteLine("============Game Has Tied============");
            } 
        }
    }
}

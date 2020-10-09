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


    }
}

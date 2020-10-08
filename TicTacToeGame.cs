using System;
using System.Collections.Generic;
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
    }
}

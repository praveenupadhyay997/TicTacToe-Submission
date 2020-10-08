using System;
using System.Linq;

namespace TicTacToeGame
{
    class Program
    {
        public static char[] board = new char[10];
        public static int[] index = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static void chooseOptions()
        {
            Console.WriteLine("Enter your Choice user X or O=");
            char userChoice = Convert.ToChar(Console.ReadLine().ToUpper());
            TicTacToeGame.ChoiceInGame(userChoice);
        }

        public static int getUserMove(char []board)
        {
            Console.WriteLine("Enter your move");
            int movePosition = Convert.ToInt32(Console.ReadLine());
            if (board[movePosition] == ' ')
                return movePosition;
            else
                return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe Game");
            
            board = TicTacToeGame.AssignBoard();
            chooseOptions();
            TicTacToeGame.ShowBoardInGame(board);
            int userMove = getUserMove(board);
            if(index.Contains(userMove))
            {
                Console.WriteLine("Eligible move");
            }
        }
    }
}

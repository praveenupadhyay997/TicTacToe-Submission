using System;

namespace TicTacToeGame
{
    class Program
    {
        public static void chooseOptions()
        {
            Console.WriteLine("Enter your Choice user=");
            char userChoice = Convert.ToChar(Console.ReadLine().ToUpper());
            TicTacToeGame.ChoiceInGame(userChoice);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe Game");
            
            char[] board = TicTacToeGame.AssignBoard();

        }
    }
}

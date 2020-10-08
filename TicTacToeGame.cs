using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToeGame
    {
        public static char[] board = new char[10];

        public static char[] AssignBoard()
        {
            for(int i=0; i<board.Length;i++)
            {
                board[i] = ' ';
            }
            return board;
        }
    }
}

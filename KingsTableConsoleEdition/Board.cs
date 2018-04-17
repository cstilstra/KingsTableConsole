using System;
namespace KingsTableConsoleEdition
{
    public class Board
    {

        char[,] board;

        public Board()
        {
        }

        public void MakeBoard(int height)
        {
            board = new char[height, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    board[i, j] = '_';
                }
            }
        }

        public char[,] GetBoard()
        {
            return board;
        }
    }
}

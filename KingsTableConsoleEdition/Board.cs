using System;
namespace KingsTableConsoleEdition
{
    public class Board
    {

        public int heightWidth;
        char[,] currentBoard;

        public Board()
        {
        }

        public void MakeBoard(int height)
        {
            heightWidth = height;
            currentBoard = new char[heightWidth, heightWidth];
            //// fill board with empty indicators
            //for (int i = 0; i < heightWidth; i++)
            //{
            //    for (int j = 0; j < heightWidth; j++)
            //    {
            //        currentBoard[i, j] = '_';
            //    }
            //}
        }

        public void SetBoard(char[,] newBoard){
            currentBoard = newBoard;
        }

        public char[,] GetBoard()
        {
            return currentBoard;
        }

        public void SetPositionToValue(int[] position, char value)
        {
            try
            {
                int x = position[0];
                int y = position[1];
                currentBoard[x, y] = value;
            }catch (System.Exception e)//TODO: catch index out of bounds exception
            {
                Console.WriteLine("");
                Console.WriteLine("Error encountered in Board.cs");
                Console.WriteLine("SetPositionToValue()");
                Console.WriteLine(e);
                Console.WriteLine("");
            }
        }
    }
}

using System;
namespace KingsTableConsoleEdition
{
    public class Board
    {

        public int heightWidth;
        char[,] currentBoard;
        int[,] corners;
        int[] throne;

        public Board()
        {
        }

        public void MakeBoard(int height)
        {
            heightWidth = height;
            currentBoard = new char[heightWidth, heightWidth];
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

        public void CreateEmptySpaces(char emptyChar)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    int[] position = { i, j };
                    SetPositionToValue(position, emptyChar);
                }
            }
        }

        public void MarkCornersAsGoals(char goalChar)
        {
            FindCorners();
            for (int i = 0; i < corners.GetLength(0); i++)
            {
                int[] position = { corners[i, 0], corners[i, 1] };
                SetPositionToValue(position, goalChar);
            }
        }

        public void FindCorners()
        {
            corners = new[,] {{0,0}, {0,10}, {10,0},
                              {10,10} };
        }

        public void MarkCenterAsThrone(char throneChar)
        {
            throne = new int[] { 5, 5 };
            SetPositionToValue(throne, throneChar);
        }

        public void PlaceKingOnThrone(char kingChar)
        {
            int[] position = new int[] { 5, 5 };
            SetPositionToValue(throne, kingChar);
        }
    }
}

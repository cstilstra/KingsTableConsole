using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    public class MainRules : IRules
    {
        Board board;
        int[,] corners;

        public MainRules()
        {
        }

        public void StartNewGame(Board newBoard)
        {
            board = newBoard;
            FindCorners();
            MarkCornersAsGoals();
        }

        void FindCorners()
        {
            int boardDimension = board.heightWidth;
            corners = new[,] {{0,0}, {0,boardDimension-1}, {boardDimension-1,0},
                              {boardDimension-1,boardDimension-1} };
        }

        void MarkCornersAsGoals()
        {
            Console.WriteLine("corners.GetLength(0) = " + corners.GetLength(0).ToString());
            for (int i = 0; i < corners.GetLength(0); i++)
            {
                int[] position = { corners[i, 0], corners[i, 1] };
                board.SetPositionToValue(position, 'X');
            }
        }
    }
}

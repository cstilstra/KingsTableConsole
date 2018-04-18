using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    public class MainRules : IRules
    {
        Board board;
        int[,] corners;

        char goalChar;

        public MainRules()
        {
            goalChar = 'X';
        }

        public void StartNewGame(Board newBoard)
        {
            board = newBoard;
            if (board.heightWidth == 11)
            {
                FindCorners();
                MarkCornersAsGoals();
                PlaceAttackers();
            }else{
                Console.WriteLine("");
                Console.WriteLine("The current board is not compatible with this rule type");
                Console.WriteLine("The rules require board height/width of 11");
                Console.WriteLine("");
            }
        }

        void FindCorners()
        {
                corners = new[,] {{0,0}, {0,10}, {10,0},
                              {10,10} };
        }

        void MarkCornersAsGoals()
        {
            for (int i = 0; i < corners.GetLength(0); i++)
            {
                int[] position = { corners[i, 0], corners[i, 1] };
                board.SetPositionToValue(position, goalChar);
            }
        }

        void PlaceAttackers()
        {
            int[] position;
            for (int i = 3; i < 8; i++)
            {
                position = new int[] { i, 0 };
                board.SetPositionToValue(position, 'A');
                position = new int[] { i, 10 };
                board.SetPositionToValue(position, 'A');
                position = new int[] { 0, i };
                board.SetPositionToValue(position, 'A');
                position = new int[] { 10, i };
                board.SetPositionToValue(position, 'A');
            }
            position = new int[] { 5, 1 };
            board.SetPositionToValue(position, 'A');
            position = new int[] { 5, 9 };
            board.SetPositionToValue(position, 'A');
            position = new int[] { 1, 5 };
            board.SetPositionToValue(position, 'A');
            position = new int[] { 9, 5 };
            board.SetPositionToValue(position, 'A');
        }
    }
}

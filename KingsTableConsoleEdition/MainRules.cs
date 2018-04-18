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
            if (board.heightWidth == 11)
            {
                FindCorners();
                MarkCornersAsGoals();
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
            Console.WriteLine("corners.GetLength(0) = " + corners.GetLength(0).ToString());
            for (int i = 0; i < corners.GetLength(0); i++)
            {
                int[] position = { corners[i, 0], corners[i, 1] };
                board.SetPositionToValue(position, 'X');
            }
        }
    }
}

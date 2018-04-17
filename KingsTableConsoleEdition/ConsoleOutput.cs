using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    public class ConsoleOutput : IOutput
    {
        public ConsoleOutput()
        {
            Console.WriteLine("Welcome to 'King's Table: Console Edition'");
        }

        public void ShowBoard(char[,] board)
        {
            String separator = "|";

            Console.WriteLine("");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write(separator);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j].ToString() + separator);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public void ShowResult()
        {
            Console.WriteLine("The game result will go here");
        }

        public void PrintString(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
    }
}

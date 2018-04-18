using System;
using System.Text;
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
                StringBuilder builder = new StringBuilder();
                builder.Append(separator);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    builder.Append(board[i, j].ToString()).Append(separator);
                }
                Console.WriteLine(builder);
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

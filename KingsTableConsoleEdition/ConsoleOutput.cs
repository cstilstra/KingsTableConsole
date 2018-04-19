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
            // build top guide line
            StringBuilder builder = new StringBuilder();
            builder.Append("    ");
            for (int j = 0; j < board.GetLength(1); j++)
            {
                builder.Append((char)(j + 97)); // convert to letters
                builder.Append(" ");
            }
            Console.WriteLine(builder);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                builder = new StringBuilder();
                // add left guide line entry
                if (i < 9) builder.Append(" ");
                builder.Append(i + 1);
                builder.Append(" ");
                // add rest of line
                builder.Append(separator);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    builder.Append(board[i, j].ToString());
                    builder.Append(separator);
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

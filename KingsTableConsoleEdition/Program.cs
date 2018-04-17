using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    class MainClass
    {

        static IOutput consoleOutput;
        static Board board;

        public static void Main(string[] args)
        {
            consoleOutput = new ConsoleOutput();
            board = new Board();
            board.MakeBoard(11);

            consoleOutput.ShowBoard(board.GetBoard());
            consoleOutput.ShowResult();
        }
    }
}

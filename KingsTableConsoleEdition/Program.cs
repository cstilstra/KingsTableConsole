using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    class MainClass
    {

        static IOutput output;
        static Board board;
        static IRules rules;

        public static void Main(string[] args)
        {
            output = new ConsoleOutput();
            board = new Board();
            rules = new MainRules();

            board.MakeBoard(11);
            rules.StartNewGame(board);

            output.ShowBoard(board.GetBoard());
            output.ShowResult();
        }
    }
}

using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    class MainClass
    {

        static IOutput output;
        static IInput input;
        static Board board;
        static IRules rules;

        public static void Main(string[] args)
        {
            output = new ConsoleOutput();
            input = new ConsoleInput();
            board = new Board();
            rules = new MainRules();

            board.MakeBoard(11);
            bool prepared = rules.PrepareNewGame(board, input);
            if(prepared)
            {
                output.ShowBoard(board.GetBoard());
            }else{
                output.PrintString("Program unable to build board, aborting.");
            }
        }
    }
}

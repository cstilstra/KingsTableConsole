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

            rules.PrintIntro(output);
            board.MakeBoard(11);
            bool preparedToStart = rules.PrepareNewGame(board, input);
            if(preparedToStart)
            {
                //TODO: move output.ShowBoard call once main loop implemented
                //output.ShowBoard(board.GetBoard());

                //TODO: output.PrintString(IRules.GetIntro());

                //TODO: main loop goes here
                while(rules.GameContinues())
                {
                    string[] move = input.GetMoveFromPlayer();
                    if(rules.MoveIsValid())
                    {
                        rules.ApplyMove(move);
                        output.ShowBoard(board.GetBoard());
                    }
                }

            }else{
                output.PrintString("Program unable to build board, aborting.");
            }
        }
    }
}

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
        static IPlayer[] players;

        public static void Main(string[] args)
        {
            output = new ConsoleOutput();
            input = new ConsoleInput();
            board = new Board();
            rules = new MainRules();

            board.MakeBoard(11);
            players = GetPlayers();
            bool preparedToStart = rules.PrepareNewGame(board, players);
            if(preparedToStart)
            {
                output.PrintString(rules.GetIntro());
                output.ShowBoard(board.GetBoard());

                //main loop
                while(rules.GameContinues())
                {
                    int[][] move = input.GetMoveFromPlayer();                   
                    rules.ApplyMove(move);
                    output.ShowBoard(board.GetBoard());
                }

            }else{
                output.PrintString("Program unable to prepare game, aborting.");
            }
        }

        static IPlayer[] GetPlayers(){
            IPlayer attacker = new HumanPlayer();
            string prompt = "Please type the name of the Attacking player:";
            attacker.SetName(input.GetStringFromPlayer(prompt));
            IPlayer defender = new HumanPlayer();
            prompt = "Please type the name of the Defending player:";
            defender.SetName(input.GetStringFromPlayer(prompt));

            //TODO: remove
            Console.WriteLine("Attacker: " + attacker.GetName());
            Console.WriteLine("Defender: " + defender.GetName());

            IPlayer[] temp = { attacker, defender };
            return temp;
        }
    }
}

using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    class Program
    {

        static IOutput _output;
        static IInput _input;
        static Board board;
        static IRules rules;
        static IPlayer[] players;

        public Program(IInput input, IOutput output)
        {
            _input = input;
            _output = output;

            board = new Board();
            rules = new MainRules();
        }

        public void Run() {

            board.MakeBoard(11);
            players = GetPlayers();
            bool preparedToStart = rules.PrepareNewGame(board, players);
            if (preparedToStart)
            {
                _output.PrintString(rules.GetIntro());
                _output.ShowBoard(board.GetBoard());

                //main loop
                while (rules.GameContinues())
                {
                    int[][] move = _input.GetMoveFromPlayer();
                    rules.ApplyMove(move);
                    _output.ShowBoard(board.GetBoard());
                }

            } else {
                _output.PrintString("Program unable to prepare game, aborting.");
            }
        }
    

        static IPlayer[] GetPlayers(){
            IPlayer attacker = new HumanPlayer();
            string prompt = "Please type the name of the Attacking player:";
            attacker.SetName(_input.GetStringFromPlayer(prompt));
            IPlayer defender = new HumanPlayer();
            prompt = "Please type the name of the Defending player:";
            defender.SetName(_input.GetStringFromPlayer(prompt));

            //TODO: remove
            Console.WriteLine("Attacker: " + attacker.GetName());
            Console.WriteLine("Defender: " + defender.GetName());

            IPlayer[] temp = { attacker, defender };
            return temp;
        }
    }
}

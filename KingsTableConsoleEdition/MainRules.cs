using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    public class MainRules : IRules
    {
        Board board;
        int[,] corners;
        int[] throne;
        IPlayer attacker, defender;
        bool gameOver;

        char emptyChar, goalChar, throneChar, attackerChar, defenderChar, kingChar;

        public MainRules()
        {
            emptyChar = '_';
            goalChar = 'X';
            throneChar = '+';
            attackerChar = 'A';
            defenderChar = 'D';
            kingChar = 'K';

            gameOver = false;
        }

        public void PrintIntro(IOutput output)
        {
            output.PrintString("-This is a custom King's Table ruleset-");
            output.PrintString("-designed by c.s.tilstra and IVSugz-");
        }
        public bool PrepareNewGame(Board newBoard, IInput input)
        {
            //TODO: Rules should create the board rather than have it passed in
            // and the board should be owned by Rules rather than Program
            board = newBoard; 
            if (board.heightWidth == 11)
            {
                //TODO: Move to Board
                CreateEmptySpaces();
                MarkCornersAsGoals();
                MarkCenterAsThrone();
                // end Move to Board
                PlaceAttackers();
                PlaceDefenders();
                PlaceKingOnThrone();
                CreatePlayers(input);
                return true;
            }else{
                Console.WriteLine("");
                Console.WriteLine("The current board is not compatible with this rule type");
                Console.WriteLine("The rules require board height/width of 11");
                Console.WriteLine("");
                return false;
            }
        }

        // Non Interface defined functions below

        void CreateEmptySpaces()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    int[] position = { i, j };
                    board.SetPositionToValue(position, emptyChar);
                }
            }
        }

        void MarkCornersAsGoals()
        {
            FindCorners();
            for (int i = 0; i < corners.GetLength(0); i++)
            {
                int[] position = { corners[i, 0], corners[i, 1] };
                board.SetPositionToValue(position, goalChar);
            }
        }

        void FindCorners()
        {
            corners = new[,] {{0,0}, {0,10}, {10,0},
                              {10,10} };
        }

        void MarkCenterAsThrone()
        {
            throne = new int[]{ 5, 5};
            board.SetPositionToValue(throne, throneChar);
        }

        void PlaceAttackers()
        {
            int[] position;
            for (int i = 3; i < 8; i++)
            {
                position = new int[] { i, 0 };
                board.SetPositionToValue(position, attackerChar);
                position = new int[] { i, 10 };
                board.SetPositionToValue(position, attackerChar);
                position = new int[] { 0, i };
                board.SetPositionToValue(position, attackerChar);
                position = new int[] { 10, i };
                board.SetPositionToValue(position, attackerChar);
            }
            position = new int[] { 5, 1 };
            board.SetPositionToValue(position, attackerChar);
            position = new int[] { 5, 9 };
            board.SetPositionToValue(position, attackerChar);
            position = new int[] { 1, 5 };
            board.SetPositionToValue(position, attackerChar);
            position = new int[] { 9, 5 };
            board.SetPositionToValue(position, attackerChar);
        }

        void PlaceDefenders()
        {
            int[] position = new int[] { 3 , 5 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 4, 4 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 4, 5 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 4, 6 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 5, 3 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 5, 4 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 5, 6 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 5, 7 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 6, 4 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 6, 5 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 6, 6 };
            board.SetPositionToValue(position, defenderChar);
            position = new int[] { 7, 5 };
            board.SetPositionToValue(position, defenderChar);
        }

        void PlaceKingOnThrone()
        {
            int[] position = new int[] { 5, 5 };
            board.SetPositionToValue(throne, kingChar);
        }

        void CreatePlayers(IInput input)
        {
            attacker = new HumanPlayer();
            string prompt = "Please type the name of the Attacking player:";
            attacker.SetName(input.GetStringFromPlayer(prompt));
            defender = new HumanPlayer();
            prompt = "Please type the name of the Defending player:";
            defender.SetName(input.GetStringFromPlayer(prompt));

            //TODO: remove
            Console.WriteLine("Attacker: " + attacker.GetName());
            Console.WriteLine("Defender: " + defender.GetName());
        }

        public bool GameContinues()
        {
            return true;
        }

        public bool MoveIsValid()
        {
            return true;
        }

        public void ApplyMove(string[] move)
        {
            
        }
    }
}

using System;
using System.Text;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    public class MainRules : IRules
    {
        Board board;
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

        public string GetIntro()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("");
            builder.AppendLine("-This is a custom King's Table ruleset-");
            builder.AppendLine("-designed by c.s.tilstra and IVSugz-");
            return builder.ToString();
        }

        public bool PrepareNewGame(Board newBoard, IPlayer[] players)
        {
            board = newBoard; 
            if (board.heightWidth == 11)
            {
                board.CreateEmptySpaces(emptyChar);
                board.MarkCornersAsGoals(goalChar);
                board.MarkCenterAsThrone(throneChar);
                board.PlaceKingOnThrone(kingChar);
                PlaceAttackers();
                PlaceDefenders();
                SetPlayers(players);
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

        void SetPlayers(IPlayer[] players)
        {
            attacker = players[0];
            defender = players[1];
            try
            {
                attacker = players[0];
                defender = players[1];
            }
            catch (System.Exception e)//TODO: catch index out of bounds exception and null instance exception
            {
                Console.WriteLine("");
                Console.WriteLine("Error encountered in MainRules.cs");
                Console.WriteLine("SetPlayers()");
                Console.WriteLine(e);
                Console.WriteLine("");
            }
        }

        public bool GameContinues()
        {
            return !gameOver;
        }

        public bool MoveIsValid(string[] move)
        {
            return true;
        }

        public void ApplyMove(string[] move)
        {
            
        }
    }
}

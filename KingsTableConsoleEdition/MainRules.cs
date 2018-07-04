using System;
using System.Collections.Generic;
using System.Text;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    public class MainRules : IRules
    {
        Board board;
        IPlayer attacker, defender;
        bool gameOver;

		char emptyChar, goalChar, throneChar, attackerChar, defenderChar, kingChar, highlightChar; //TODO: make enum
        List<int[]> highlighted;
		int[] kingPosition;

		public MainRules()
        {
            emptyChar = '_';
            goalChar = 'X';
            throneChar = '+';
            attackerChar = 'A';
            defenderChar = 'D';
            kingChar = 'K';
            highlightChar = '0';

            highlighted = new List<int[]>();

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
                board.SetEmptyBoard(board.GetBoard());
                PlaceKingOnThrone();
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

        public bool GameContinues()
        {
            return !gameOver;
        }

        public bool MoveIsValid(int[][] move)
        {
			//TODO: check that the first position is not empty
			//TODO: check that the character at first position belongs to current player
            //check if there is a destination position and return true if not
            if(move[1].Length == 0){
                return true;
            }
            //check that character at first position can move to second position
            List<int[]> moves = GetMovesForPieceAt(move[0]);
            for (int i = 0; i < moves.Count; i++)
            {
                int[] position = { moves[i][0], moves[i][1] };
                if(position[0] == move[1][0] & position[1] == move[1][1]){
                    return true;
                }
            }
            Console.WriteLine("That piece cannot move there.");
            return false; 
        }

        public void ApplyMove(int[][] move)
        {
			if (MoveIsValid(move))
			{
				//clear display characters
				RemoveHighlights();
				//display moves for unit at first position
				//TODO: make function
				List<int[]> moves = GetMovesForPieceAt(move[0]);
				for (int i = 0; i < moves.Count; i++)
				{
					int[] position = { moves[i][0], moves[i][1] };
					board.SetPositionToValue(position, highlightChar);
				}
				highlighted = moves;
				//try to move unit to second position, then clear display characters
				char pieceMoving = board.GetValueAt(move[0]);
				try
				{
					board.MovePiece(move[0], move[1]);
					RemoveHighlights();
					if(board.GetValueAt(move[1]) == kingChar){
						kingPosition = move[1];
					}
				}
				catch (IndexOutOfRangeException e)
				{
					//Console.WriteLine(e);

                    //set piece back to original position
					board.SetPositionToValue(move[0], pieceMoving); 
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}

				CheckForCapture(move[1]);
                CheckForWin();
			}
        }

        public List<int[]> GetMovesForPieceAt(int[] position) //TODO: allow the King to move to the throne and the goals
        {
			char moving = board.GetValueAt(position);
            int y = position[0];
            int x = position[1];
            //Console.Write("y = " + y);
            //Console.WriteLine(", x = " + x);
            List<int[]> moves = new List<int[]>();

            // look up
            for (int i = y - 1; i >= 0; i--){
                int[] tempPosition = { i, x };
                char occupant = board.GetValueAt(tempPosition);
				if(moving == kingChar && board.PositionIsReservedForKing(tempPosition)){
					moves.Add(tempPosition);
				}else if(occupant == emptyChar || occupant == highlightChar){
                    moves.Add(tempPosition);
                }else{
                    break;
                }
            }
            // look right
            for (int i = x + 1; i <= 10; i++)
            {
				//TODO: make function
                int[] tempPosition = { y, i };
                char occupant = board.GetValueAt(tempPosition);
				if (moving == kingChar && board.PositionIsReservedForKing(tempPosition))
                {
                    moves.Add(tempPosition);
                }
                else if (occupant == emptyChar || occupant == highlightChar)
                {
                    moves.Add(tempPosition);
                }
                else
                {
                    break;
                }
            }
            // look down
            for (int i = y + 1; i <= 10; i++)
            {
                int[] tempPosition = { i, x };
                char occupant = board.GetValueAt(tempPosition);
				if (moving == kingChar && board.PositionIsReservedForKing(tempPosition))
                {
                    moves.Add(tempPosition);
                }
                else if (occupant == emptyChar || occupant == highlightChar)
                {
                    moves.Add(tempPosition);
                }
                else
                {
                    break;
                }
            }
            // look left
            for (int i = x - 1; i >= 0; i--)
            {
                int[] tempPosition = { y, i };
                char occupant = board.GetValueAt(tempPosition);
				if (moving == kingChar && board.PositionIsReservedForKing(tempPosition))
                {
                    moves.Add(tempPosition);
                }
                else if (occupant == emptyChar || occupant == highlightChar)
                {
                    moves.Add(tempPosition);
                }
                else
                {
                    break;
                }
            }

            return moves;
        }


        // Non Interface defined functions below

		void PlaceKingOnThrone(){
			board.SetPositionToValue(board.throne, kingChar);
			kingPosition = board.throne;
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

        void SetPlayers(IPlayer[] players)
        {
            attacker = players[0];
            defender = players[1];
            try
            {
                attacker = players[0];
                defender = players[1];
            }
            catch (System.Exception e)//TODO: catch null instance exception
            {
                Console.WriteLine("");
                Console.WriteLine("Error encountered in MainRules.cs");
                Console.WriteLine("SetPlayers()");
                Console.WriteLine(e);
                Console.WriteLine("");
            }
        }

		void RemoveHighlights(){
            for (int i = 0; i < highlighted.Count; i++)
            {
                if (board.GetValueAt(highlighted[i]) == highlightChar)
                {
                    board.SetPositionToValue(highlighted[i], emptyChar);
                }
            }
        }
        
		void CheckForCapture(int [] position){
			char pieceAt = board.GetValueAt(position);
			if (pieceAt == attackerChar || pieceAt == defenderChar)
			{
				//TODO: create helper function
				// look at each neighboring space checking for enemy
				//up
				int[] adjacentPosition = { position[0] - 1, position[1] };
				char adjacentPiece = board.GetValueAt(adjacentPosition);
				if((adjacentPiece == attackerChar || adjacentPiece == defenderChar) && 
				   (adjacentPiece != pieceAt)){
					// look at the piece beyond
					int[] beyondPosition = new int[]{ position[0] - 2, position[1] };
					char nextPiece = board.GetValueAt(beyondPosition);
					if(nextPiece == pieceAt){
						board.RemovePieceAt(adjacentPosition);
						Console.WriteLine("Piece removed");
					}
				}
                //down
				adjacentPosition = new int[]{ position[0] + 1, position[1] };
                adjacentPiece = board.GetValueAt(adjacentPosition);
                if ((adjacentPiece == attackerChar || adjacentPiece == defenderChar) &&
                   (adjacentPiece != pieceAt))
                {
                    // look at the piece beyond
                    int[] beyondPosition = new int[] { position[0] + 2, position[1] };
                    char nextPiece = board.GetValueAt(beyondPosition);
                    if (nextPiece == pieceAt)
                    {
                        board.RemovePieceAt(adjacentPosition);
                        Console.WriteLine("Piece removed");
                    }
                }
                //left
				adjacentPosition = new int[] { position[0], position[1] - 1 };
                adjacentPiece = board.GetValueAt(adjacentPosition);
                if ((adjacentPiece == attackerChar || adjacentPiece == defenderChar) &&
                   (adjacentPiece != pieceAt))
                {
                    // look at the piece beyond
                    int[] beyondPosition = new int[] { position[0], position[1] -2 };
                    char nextPiece = board.GetValueAt(beyondPosition);
                    if (nextPiece == pieceAt)
                    {
                        board.RemovePieceAt(adjacentPosition);
                        Console.WriteLine("Piece removed");
                    }
                }
                //right
				adjacentPosition = new int[] { position[0], position[1] + 1 };
                adjacentPiece = board.GetValueAt(adjacentPosition);
                if ((adjacentPiece == attackerChar || adjacentPiece == defenderChar) &&
                   (adjacentPiece != pieceAt))
                {
                    // look at the piece beyond
                    int[] beyondPosition = new int[] { position[0], position[1] + 2 };
                    char nextPiece = board.GetValueAt(beyondPosition);
                    if (nextPiece == pieceAt)
                    {
                        board.RemovePieceAt(adjacentPosition);
                        Console.WriteLine("Piece removed");
                    }
                }
			}
		}

		void CheckForWin(){
			//check if King is surrounded

            //check if King is in corner
		}
    }
}

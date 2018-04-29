using System;
namespace KingsTableConsoleEdition
{
    public class Board
    {

        public int heightWidth;
        char[,] currentBoard;
        int[,] corners;
        int[] throne;
        char empty;


        public Board()
        {
        }

        public void MakeBoard(int height)
        {
            heightWidth = height;
            currentBoard = new char[heightWidth, heightWidth];
        }

        public void SetBoard(char[,] newBoard){
            currentBoard = newBoard;
        }

        public char[,] GetBoard()
        {
            return currentBoard;
        }

        public char GetValueAt(int[] position)
        {
            return currentBoard[position[0], position[1]];
        }

        public void SetPositionToValue(int[] position, char value)
        {
            try
            {
                int x = position[0];
                int y = position[1];
                currentBoard[x, y] = value;
            }catch (IndexOutOfRangeException e)//TODO: catch index out of bounds exception and null instance exception
            {
                throw e;
            }catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("Error encountered in Board.cs");
                Console.WriteLine("SetPositionToValue()");
                Console.WriteLine(ex);
                Console.WriteLine("");
            }
        }

        public void CreateEmptySpaces(char emptyChar)
        {
            empty = emptyChar;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    int[] position = { i, j };
                    SetPositionToValue(position, empty);
                }
            }
        }

        public void MarkCornersAsGoals(char goalChar)
        {
            FindCorners();
            for (int i = 0; i < corners.GetLength(0); i++)
            {
                int[] position = { corners[i, 0], corners[i, 1] };
                SetPositionToValue(position, goalChar);
            }
        }

        public void FindCorners()
        {
            corners = new[,] {{0,0}, {0,10}, {10,0},
                              {10,10} };
        }

        public void MarkCenterAsThrone(char throneChar)
        {
            throne = new int[]{ 5, 5 };
            SetPositionToValue(throne, throneChar);
        }

        public void PlaceKingOnThrone(char kingChar)
        {
            int[] position = { 5, 5 };
            SetPositionToValue(throne, kingChar);
        }

        public void RemovePieceAt(int[] position)
        {
            SetPositionToValue(position, empty);
        }

        public void MovePiece(int[] piecePosition, int[] destinationPosition)
        {
            // get the piece at piecePosition
            char piece = currentBoard[piecePosition[0], piecePosition[1]];
            // check that piece is not empty
            if(!piece.Equals(empty))
            {
                // move piece
                RemovePieceAt(piecePosition);
                SetPositionToValue(destinationPosition, piece);
            }
        }
    }
}

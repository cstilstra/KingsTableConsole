using System;
using System.Collections.Generic;

namespace KingsTableConsoleEdition.Interfaces
{
    public interface IRules
    {
        string GetIntro();
        bool PrepareNewGame(Board newBoard, IPlayer[] players);
        bool GameContinues();
        bool MoveIsValid(int[][] move);
        void ApplyMove(int[][] move);
        List<int[]> GetMovesForPieceAt(int[] position);
    }
}

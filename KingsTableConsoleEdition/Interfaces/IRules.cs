using System;
namespace KingsTableConsoleEdition.Interfaces
{
    public interface IRules
    {
        string GetIntro();
        bool PrepareNewGame(Board newBoard, IPlayer[] players);
        bool GameContinues();
        bool MoveIsValid(string[] move);
        void ApplyMove(string[] move);
    }
}

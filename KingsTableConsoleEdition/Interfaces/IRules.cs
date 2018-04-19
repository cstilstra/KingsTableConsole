using System;
namespace KingsTableConsoleEdition.Interfaces
{
    public interface IRules
    {
        void PrintIntro(IOutput output);
        //TODO: Rules should create the board rather than have it passed in
        bool PrepareNewGame(Board newBoard, IInput input);
        bool GameContinues();
        bool MoveIsValid();
        void ApplyMove(string[] move);
    }
}

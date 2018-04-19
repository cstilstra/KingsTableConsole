using System;
namespace KingsTableConsoleEdition.Interfaces
{
    public interface IPlayer
    {
        void SetName(string name);
        string GetName();
        void AddWin();
        int GetWins();
        void AddLoss();
        int GetLosses();
        void AddDraw();
        int GetDraws();
    }
}

using System;
namespace KingsTableConsoleEdition.Interfaces
{
    public interface IInput
    {
        string GetStringFromPlayer(string prompt);
        int[][] GetMoveFromPlayer();
    }
}

using System;
namespace KingsTableConsoleEdition.Interfaces
{
    public interface IRules
    {

        bool PrepareNewGame(Board newBoard, IInput input);

    }
}

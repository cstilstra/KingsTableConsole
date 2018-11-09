using System;
namespace KingsTableConsoleEdition.Interfaces
{
    public interface IOutput
    {

        void ShowBoard(char[,] board);
        void ShowResult();
        void PrintString(string toPrint);

    }
}

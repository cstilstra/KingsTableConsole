using System;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    public class ConsoleInput : IInput
    {
        public ConsoleInput()
        {
        }

        public string[] GetMoveFromPlayer()
        {
            throw new NotImplementedException();
        }

        public string GetStringFromPlayer(string prompt)
        {
            Console.WriteLine("");
            Console.WriteLine(prompt);
            string rawInput = Console.ReadLine();
            string trimmedInput = rawInput.Trim();
            return trimmedInput;
        }
    }
}

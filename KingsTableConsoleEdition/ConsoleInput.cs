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
            Console.WriteLine("Press 'Enter' twice.");
            string string1 = Console.ReadLine();
            string string2 = Console.ReadLine();
            return new string[] { string1, string2 };
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

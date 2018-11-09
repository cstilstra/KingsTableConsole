namespace KingsTableConsoleEdition
{
    class ConsoleDriver
    {
        static ConsoleInput consoleInput;
        static ConsoleOutput consoleOutput;

        static void Main(string[] args)
        {
            consoleInput = new ConsoleInput();
            consoleOutput = new ConsoleOutput();

            Program program = new Program(consoleInput, consoleOutput);
            program.Run();
        }

    }
}

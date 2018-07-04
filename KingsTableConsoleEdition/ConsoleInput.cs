using System;
using System.Text;
using KingsTableConsoleEdition.Interfaces;
namespace KingsTableConsoleEdition
{
    public class ConsoleInput : IInput
    {

        public ConsoleInput()
        {
        }

        public int[][] GetMoveFromPlayer() // TODO: input validation 
        {

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Enter a piece position to see available moves");
            builder.AppendLine("or a piece position and an empty position");
            builder.AppendLine("separated by a space to move the piece.");
            builder.AppendLine("Examples: 'fo' and 'fo jo' are valid inputs.");
            string prompt = builder.ToString();
            string input = GetStringFromPlayer(prompt);
            if(input.Length == 2)
            {
                int[] position = TransformStringToPosition(input);
                int[] empty = { };
                int[][] toReturn = { position, empty };
                return toReturn;
            }else{
                int[] position = TransformStringToPosition(input.Substring(0, 2));
                int[] empty = TransformStringToPosition(input.Substring(3));
                int[][] toReturn = { position, empty };
                return toReturn;
            }


        }

        public string GetStringFromPlayer(string prompt)
        {
            Console.WriteLine("");
            Console.WriteLine(prompt);
            string rawInput = Console.ReadLine();
            string trimmedInput = rawInput.Trim();
            return trimmedInput;
        }

        int[] TransformStringToPosition(string inputString)
        {
			try
			{
				char toTransform = inputString.Substring(0, 1).ToCharArray()[0];
				int transformedA = (Convert.ToInt32(toTransform) - 97);
				toTransform = inputString.Substring(1).ToCharArray()[0];
				int transformedB = (Convert.ToInt32(toTransform) - 108);
				return new int[] { transformedA, transformedB };
			}catch(IndexOutOfRangeException ex){
				
			}

			return new int[] { -1, -1};
        }
    }
}

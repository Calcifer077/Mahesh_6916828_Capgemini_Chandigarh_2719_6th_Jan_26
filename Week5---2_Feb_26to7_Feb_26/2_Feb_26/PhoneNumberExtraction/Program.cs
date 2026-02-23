using System.Text.RegularExpressions;

namespace PhoneNumberExtraction
{
    internal class Program{

        static void Main(string[] args)
        {
            string input = "Call me at 9876543210 or 9123456789.";

            // Regex for exactly 10-digit phone numbers
            Regex regex = new Regex(@"\b\d{10}\b");

            // Find all matches
            MatchCollection matches = regex.Matches(input);

            // Print each phone number on a new line
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
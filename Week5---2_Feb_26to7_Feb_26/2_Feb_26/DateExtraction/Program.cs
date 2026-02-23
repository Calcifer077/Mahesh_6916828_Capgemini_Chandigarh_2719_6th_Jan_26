using System.Text.RegularExpressions;

namespace DateExtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Our trip is on 15/02/2026 and return on 25/02/2026.";

            // Regex for dd/mm/yyyy format
            Regex regex = new Regex(@"\b\d{2}/\d{2}/\d{4}\b");

            // Find all matches
            MatchCollection matches = regex.Matches(input);

            // Print each date on a new line
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
using System.Text.RegularExpressions;

namespace HashtagExtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Loving the vibes! #Travel #Adventure #2026Goals";

            // Regex for hashtags
            Regex regex = new Regex(@"#\w+");

            // Find all matches
            MatchCollection matches = regex.Matches(input);

            // Print each hashtag on a new line
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
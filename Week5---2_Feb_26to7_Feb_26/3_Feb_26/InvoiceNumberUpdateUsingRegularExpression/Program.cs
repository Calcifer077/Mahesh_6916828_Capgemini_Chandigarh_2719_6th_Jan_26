using System.Text.RegularExpressions;

namespace InvoiceNumberUpdateUsingRegularExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "CAP-123";

            Match m1 = Regex.Match(input, @"\d+$");

            int m1Val = Convert.ToInt32(m1.Value);

            m1Val += 7;
            string output = input.Substring(0, 4) + m1Val.ToString();

            Console.WriteLine(output);

        }
    }
}
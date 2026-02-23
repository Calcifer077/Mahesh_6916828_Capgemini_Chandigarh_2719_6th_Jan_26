using System.Text.RegularExpressions;

namespace LocationCodeUpdateInInvoiceNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "CAP-HYD-1234";

            Console.WriteLine(input.Substring(0, 4) + "BAN" + input.Substring(7));

            
        }
    }
}
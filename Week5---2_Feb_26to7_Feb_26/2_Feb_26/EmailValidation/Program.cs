using System.Text.RegularExpressions;

namespace EmailValidation
{
    internal class Program{
        public static string isValid(string email){
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Invalid";
            }

            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            if(Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase)) return "Valid";
            return "Invalid";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(isValid("mahes@test.c"));
        }
    }
}
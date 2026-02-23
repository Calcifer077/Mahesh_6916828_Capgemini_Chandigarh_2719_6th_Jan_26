using System.Text.RegularExpressions;

namespace StrongPasswordValidation
{
    internal class Program{

        static void Main(string[] args)
        {
            string password = "Strong@123";

            // Regex pattern for strong password
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";

            if (Regex.IsMatch(password, pattern))
            {
                Console.WriteLine("Strong");
            }
            else
            {
                Console.WriteLine("Weak");
            }
        }
    }
}
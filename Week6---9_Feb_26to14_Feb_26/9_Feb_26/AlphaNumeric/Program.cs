using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = "a1b2c3d4";

        StringBuilder left = new StringBuilder();   // digits
        StringBuilder right = new StringBuilder();  // letters

        foreach (char c in input)
        {
            if (char.IsDigit(c))
                left.Append(c);
            else
                right.Append(c);
        }

        Console.WriteLine("Left (pushed values): " + left);
        Console.WriteLine("Right (remaining string): " + right);
    }
}
namespace IsNumberPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 12321;

            int temp = input;
            int reversedNumber = 0;

            int output = 0;

            if (input < 0)
            {
                output = -1;
            }
            else
            {

                while (temp > 0)
                {
                    int digit = temp % 10;
                    reversedNumber = reversedNumber * 10 + digit;
                    temp /= 10;
                }

                if (input == reversedNumber)
                    output = 1;
                else
                    output = -2;
            }

            Console.WriteLine("Input is " + input);
            Console.WriteLine("Output is " + output);
        }
    }
}
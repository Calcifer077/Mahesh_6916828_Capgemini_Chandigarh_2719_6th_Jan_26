using System;

namespace LeapYear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 2034;

            bool output = false;

            Console.WriteLine("Input is: " + input);

            if(input < 0)
            {
                Console.WriteLine("Output is -1");
            }
            else
            {
                bool isLeapYear = (input % 4 == 0 && input % 100 != 0) || (input % 400 == 0);

                output = isLeapYear;

                Console.WriteLine("Output is : " + output);
            }

            
        }
    }

}
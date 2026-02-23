namespace SalaryStory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1 = 7000;
            int input2 = 30;
            int output = 0;

            if (input1 > 9000)
            {
                output = -1;
            }
            else if (input1 < 0)
            {
                output = -3;
            }
            else if (input2 < 0)
            {
                output = -4;
            }
            else
            {
                if (input2 == 31)
                {
                    output += 500;
                }

                output += (int)(input1 * 0.3);
            }

            Console.WriteLine("Input salary is " + input1 + " and number of working days is: " + input2);
            Console.WriteLine("Output is: " + output);
        }
    }
}
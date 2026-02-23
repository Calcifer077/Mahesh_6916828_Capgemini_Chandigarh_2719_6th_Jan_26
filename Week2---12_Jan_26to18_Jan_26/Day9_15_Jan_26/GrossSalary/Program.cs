namespace GrossSalary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 10000;
            int days = 30;

            int output = 0;

            if(input < 0)
            {
                output = -1;
            }else if(input > 10000)
            {
                output = -2;
            }else if(days == 31)
            {
                output = -3;
            }
            else
            {
                output += input + (int)(input * 0.75) + (int)(input * 0.5);
            }

            Console.WriteLine("Basic salary is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}
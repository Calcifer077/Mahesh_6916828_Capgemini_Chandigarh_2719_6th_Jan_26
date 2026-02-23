namespace SumOfSquaresOfOddDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 132;
            int output = 0;

            if(input < 0)
            {
                output = -1;
            }
            else
            {
                int sum = 0;

                int temp = input;
                
                while(temp > 0)
                {
                    int a = temp % 10;
                    if(a % 2 == 1)
                    {
                        sum += a * a;
                    }
                    temp /= 10;
                }
                output = sum;
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}
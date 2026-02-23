namespace SumOfAllDigits
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int input = 2784;
            int output = 0;
                int temp = input;

                while (temp > 0)
                {
                    int a = temp % 10;
            
            
                        output += a;
            
                    temp /= 10;
                }
            
            
            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}

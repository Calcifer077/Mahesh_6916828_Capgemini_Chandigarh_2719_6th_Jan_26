namespace SumOfEvenDigitsQuestion8
{
    internal class Program
    {
        public void Question()
        {
            int input = 132;
            int output = 0;

            if (input < 0)
            {
                output = -1;
            }
            else if (input > 32767)
            {
                output = -2;
            }
            else
            {
                int temp = input;

                while (temp > 0)
                {
                    int a = temp % 10;
                    if (a % 2 == 0)
                    {
                        output += a;
                    }
                    temp /= 10;
                }
            }
            
            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Question();
        }
    }
}

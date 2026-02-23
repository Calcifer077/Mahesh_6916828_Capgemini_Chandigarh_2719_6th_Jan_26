namespace NumberOfDigitsQuestion3
{
    internal class Program
    {
        // find number of digits in a given number
        public void Question()
        {
            int input = 23;
            int output = 0;

            if (input < 0)
            {
                output = -1;
            }
            else
            {
                int temp = input;
                int count = 0;

                while (temp > 0)
                {
                    count++;
                    temp /= 10;
                }

                output = count;
            }

            Console.WriteLine("Input value: " + input);
            Console.WriteLine("Output value: " + output);
        }


        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Question();
        }
    }
}

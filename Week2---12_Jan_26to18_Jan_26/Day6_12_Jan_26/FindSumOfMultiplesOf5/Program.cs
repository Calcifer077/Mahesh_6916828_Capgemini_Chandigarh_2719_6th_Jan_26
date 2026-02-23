namespace FindSumOfMultiplesOf5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 2, 5, 1, 45, 1, 9 };
            int size = input.Length;
            int output = 0;

            bool hasNegative = false;

            foreach (int i in input)
            {
                if (i < 0)
                {
                    hasNegative = true; break;
                }
            }

            if (hasNegative)
            {
                output = -1;
            }
            else if (size < 0)
            {
                output = -2;
            }
            else
            {
                int count = 0;
                int sum = 0;

                foreach (int i in input)
                {
                    if (i % 5 == 0)
                    {
                        sum += i;
                        count++;
                    }
                }

                output = sum / count;
            }

            Console.WriteLine("Input is: [" + string.Join(',', input) + "]");
            Console.WriteLine("Output is: " + output);
        }
    }
}
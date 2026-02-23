namespace MaximumMinimumProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 5, 1, 9, 10, 11, 21 };
            int max = int.MinValue;
            int min = int.MaxValue;

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
            else if (input.Length < 0)
            {
                output = -2;
            }
            else
            {
                foreach (int i in input)
                {
                    max = Math.Max(max, i);
                    min = Math.Min(min, i);
                }

                output = max * min;
            }

            Console.WriteLine("Input is: [" + string.Join(',', input) + "]");
            Console.WriteLine("Output is " + output);
        }
    }
}

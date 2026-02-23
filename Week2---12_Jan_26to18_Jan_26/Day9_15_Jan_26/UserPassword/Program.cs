namespace UserPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 4, 1, 1, 1, 2, 3, 5, 1, 5, 1 };
            int output = 0;

            bool hasNeg = false;
            foreach (int i in input)
            {
                if (i < 0)
                {
                    hasNeg = true;
                    break;
                }
            }


            if (hasNeg)
            {
                output = -1;
            }
            else if (input.Length < 0)
            {
                output = -2;
            }
            else
            {
                int odd = 0, even = 0;
                foreach (int i in input)
                {
                    if (i % 2 == 0)
                    {
                        even += i;
                    }
                    else
                    {
                        odd += i;
                    }
                }

                output = (odd + even) / 2;
            }

            Console.WriteLine("Input is: [ " + string.Join(',', input) + "]");
            Console.WriteLine("Output is: " + output);

        }
    }
}
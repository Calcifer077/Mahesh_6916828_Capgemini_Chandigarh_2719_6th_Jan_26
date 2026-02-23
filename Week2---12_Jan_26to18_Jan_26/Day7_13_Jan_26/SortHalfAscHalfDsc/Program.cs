namespace SortHalfAscHalfDsc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 11, 24, 1, 2, 1, 5, 5, 0, 22 };
            int size = input.Length;

            int[] output = new int[size];

            if (size < 0)
            {
                output = new int[1];
                output[0] = -1;
            }
            else
            {
                Array.Sort(input);

                for (int i = 0; i < size / 2; i++)
                {
                    output[i] = input[i];
                }

                Array.Reverse(input);
                for (int i = 0; i < size / 2; i++)
                {
                    output[size / 2 + i] = input[i];
                }
            }

            Console.WriteLine("Input is: [" + string.Join(',', input) + "]");
            Console.WriteLine("Output is: [" + string.Join(',', output) + "]");
        }
    }
}
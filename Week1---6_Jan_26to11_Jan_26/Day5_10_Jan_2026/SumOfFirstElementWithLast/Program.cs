namespace SumOfFirstElementWithLast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 21, 23, 41, 4 };
            int[] input2 = { 3, 4, 1, 5 };
            int size = input1.Length;

            int[] output = new int[size];

            bool hasNegative = false;

            foreach (int i in input1)
            {
                if (i < 0)
                {
                    hasNegative = true;
                    break;
                }
            }

            if (hasNegative)
            {
                output[0] = -1;
            }
            else if (size < 0)
            {
                output[0] = -2;
            }
            else
            {
                Array.Reverse(input2);

                for (int i = 0; i < size; i++)
                {
                    output[i] = input1[i] + input2[i];
                }
            }

            Console.WriteLine("Input is: [" + string.Join(',', input1) + "] and [" + string.Join(',', input2) + "]");

            Console.WriteLine("Output is: [" + string.Join(',', output) + "]");
        }
    }
}
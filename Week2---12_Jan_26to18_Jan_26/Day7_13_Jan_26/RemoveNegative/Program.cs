namespace RemoveNegative
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 21, -10, 4, 78 };
            int size = input.Length;

            int[] output = new int[1];

            if (size < 0)
            {
                output[0] = -1;
            }
            else
            {
                int positiveCount = 0;

                foreach (int i in input)
                {
                    if (i >= 0)
                    {
                        positiveCount++;
                    }
                }

                output = new int[positiveCount];
                int j = 0;
                for (int i = 0; i < size; i++)
                {
                    if (!(input[i] < 0))
                    {
                        output[j++] = input[i];
                    }
                }

                Array.Sort(output);
            }

            Console.WriteLine("Input is : [ " + string.Join(',', input) + "]");
            Console.WriteLine("Output is: [ " + string.Join(',', output) + "]");
        }
    }
}
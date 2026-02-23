namespace MultipleOf3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 3, 4, 5, 6 };
            int output = 0;
            int intputArraySize = input.Length;

            Boolean hasNegative = false;

            foreach (int i in input)
            {

                if(i < 0)
                {
                    hasNegative = true;
                    break;
                }

            }

            if (hasNegative)
            {
                output = -1;
            }
            else if (intputArraySize < 0)
            {
                output = -2;
            }
            else
            {
                int count = 0;
                foreach (int i in input)
                {
                    if(i % 3 == 0)
                    {
                        count++;
                    }
                }

                output = count;
            }

            Console.Write("Input array: ");
            Console.Write("[");
            foreach (int i in input)
            {
                Console.Write(i + " ");
            }

            Console.Write("]");
            Console.WriteLine();
            Console.WriteLine("Output is: " + output);
        }
    }
}

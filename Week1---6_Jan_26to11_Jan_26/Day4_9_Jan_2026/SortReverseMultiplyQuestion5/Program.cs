namespace SortReverseMultiplyQuestion5
{
    internal class Program
    {
        public void PrintArray(int[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("]");

            Console.WriteLine();
        }

        // sort and reverse array than multiply.
        public void Question()
        {
            int[] inputArray1 = { 1, 2, 3, 4, 5 };
            int[] inputArray2 = { 9, 8, 7, 6, 5 };

            int inputArray1Size = inputArray1.Length;
            int[] output = new int[inputArray1Size];

            Boolean hasNegative = false;
            foreach (int i in inputArray1)
            {
                if (i < 0)
                {
                    hasNegative = true;
                    break;
                }
            }

            if (!hasNegative)
            {
                foreach (int i in inputArray2)
                {
                    if (i < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
            }

            if (hasNegative)
            {
                output[0] = -1;
            }
            else if (inputArray1Size < 0)
            {
                output[0] = -2;
            }
            else
            {
                Array.Sort(inputArray1);
                Array.Sort(inputArray2);
                Array.Reverse(inputArray2);

                for (int i = 0; i < inputArray1Size; i++)
                {
                    output[i] = inputArray1[i] * inputArray2[inputArray1Size - i - 1];
                }
            }

            Console.Write("Input Array1 "); PrintArray(inputArray1);
            Console.Write("Input Array2 "); PrintArray(inputArray2);
            Console.Write("Output Array "); PrintArray(output);
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Question();
        }
    }
}

namespace EvenSumOddSumAvgQuestion4
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


        // Find sum of even numbers and odd numbers, than average them.
        public void Question()
        {
            int inputArraySize;
            Console.WriteLine("Give input Array size: ");
            inputArraySize = Convert.ToInt32(Console.ReadLine());

            int[] inputArray = new int[inputArraySize];
            Console.WriteLine("Give input array elements: ");

            for (int i = 0; i < inputArraySize; i++)
            {
                inputArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            int output = 0;

            // find negative elements
            Boolean hasNegative = false;
            foreach (int i in inputArray)
            {
                if (i < 0)
                {
                    hasNegative = true;
                    break;
                }
            }

            if (hasNegative)
            {
                output = -1;
            }
            else if (inputArraySize < 0)
            {
                output = -2;
            }
            else
            {
                int evenSum = 0, oddSum = 0, average = 0;

                foreach (int i in inputArray)
                {
                    if (i % 2 == 0)
                    {
                        evenSum += i;
                    }
                    else
                    {
                        oddSum += i;
                    }
                }

                output = (evenSum + oddSum) / 2;
            }

            Console.Write("Input array: "); PrintArray(inputArray);
            Console.WriteLine("Output value: " + output);
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Question();
        }
    }
}

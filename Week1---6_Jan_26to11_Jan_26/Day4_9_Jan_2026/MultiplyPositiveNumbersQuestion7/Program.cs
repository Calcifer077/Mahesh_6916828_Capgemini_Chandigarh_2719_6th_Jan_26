namespace MultiplyPositiveNumbersQuestion7
{
    internal class Program
    {  public void PrintArray(int[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("]");

            Console.WriteLine();
        }

        // multiply the positive numbers in an array
        public void Question()
        {
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int inputArraySize = inputArray.Length;

            int output = 0;

            if (inputArraySize < 0)
            {
                output = -2;
            }
            else
            {
                int product = 1;

                foreach (int i in inputArray)
                {
                    if (i >= 0)
                    {
                        product *= i;
                    }
                }

                output = product;
            }

            Console.Write("Input array is "); PrintArray(inputArray);
            Console.WriteLine("Ouput is " + output);
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Question();
        }
    }
}

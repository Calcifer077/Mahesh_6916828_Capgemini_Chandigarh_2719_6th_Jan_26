namespace SearchForAElementQuestion9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 7, 8, 8 };
            int elementToSearch = 4;
            int output = 0;
            int inputArraySize = inputArray.Length;

            int index = Array.IndexOf(inputArray, elementToSearch);

            if (index == -1)
            {
                output = 1;
            }
            else
            {
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
                    output = index;
                }
            }

            Console.Write("Input array: ");
            foreach (int i in inputArray) Console.Write(i + " ");
            Console.WriteLine();

            Console.WriteLine("Element that was searched for: " + elementToSearch);
            Console.WriteLine("Output element: " + output);
        }
    }
}

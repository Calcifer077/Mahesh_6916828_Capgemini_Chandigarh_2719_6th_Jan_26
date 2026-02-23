namespace FindHowMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 689;
            int output = 0;

            if (input < 0)
            {
                output = -1;
            }
            else
            {

                int[] arr = { 500, 100, 50, 10, 1 };
                int count = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    while (arr[i] <= input)
                    {
                        input -= arr[i];
                        count++;
                    }
                }

                count += input;
                output = count;
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);

            

        }
    }
}
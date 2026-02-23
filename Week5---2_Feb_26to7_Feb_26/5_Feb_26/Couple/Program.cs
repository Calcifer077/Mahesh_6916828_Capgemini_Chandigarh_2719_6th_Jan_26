namespace Couple
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {2,2,4,0};

            int n = arr.Length;

            int output = 0;

            for(int i = 1; i < n; i++)
            {
                if((arr[i] + arr[i - 1]) % n == 0)
                {
                    output++;
                }
            }

            Console.WriteLine(output);
        }
    }
}

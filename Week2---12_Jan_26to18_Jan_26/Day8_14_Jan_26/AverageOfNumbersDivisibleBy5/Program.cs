namespace AverageOfNumbersDivisbleBy5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 23;
            int output = 0;

            if(input < 0)
            {
                output = -1;
            }
            else
            {
                int start = 5;
                int sum = 0, count = 0;

                while(start <= input)
                   {
                    sum += start;
                    count++;
                    start += 5;
                }

                output = sum / count;
            }

            Console.WriteLine("Input is : " + input);
            Console.WriteLine("Output is : " + output);

        }
    }
}
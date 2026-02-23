namespace FactorialOfNumberQuestion1
{
    internal class Program
    {
        // Find factorial of a number
        public void Question()
        {
            int input;
            Console.WriteLine("Give input: ");
            input = Convert.ToInt32(Console.ReadLine());

            int output = 0;

            if (input < 0)
            {
                output = -1;
            }
            else if (input > 7)
            {
                output = -2;
            }
            else
            {
                int fact = 1;
                for (int i = 1; i <= input; i++)
                {
                    fact *= i;
                }

                output = fact;
            }

            Console.WriteLine("Input value: " + input);
            Console.WriteLine("Output value: " + output);
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Question();
        }
    }
}

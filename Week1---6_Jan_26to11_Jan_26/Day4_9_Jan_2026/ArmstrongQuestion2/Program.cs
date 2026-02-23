namespace ArmstrongQuestion2
{
    internal class Program
    {

        // Armstrong number
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
            else if (input > 3)
            {
                output = -2;
            }
            else if (input == 1)
            {
                output = 1;
            }
            else
            {
                output = 0;
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

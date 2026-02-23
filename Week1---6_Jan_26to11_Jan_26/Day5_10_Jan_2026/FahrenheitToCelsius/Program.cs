namespace FahrenheitToCelsius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 43;
            int output = 0;

            if (input < 0)
            {
                output = -1;
            }
            else
            {
                double faren = Convert.ToDouble(input);
                output = Convert.ToInt32((faren - 32) * 5.0 / 9.0);
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}
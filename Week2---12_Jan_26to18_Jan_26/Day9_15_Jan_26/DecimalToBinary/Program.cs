namespace DecimalToBinary
{
    internal class Program
    {
        static int[] DecimalToBinaryArray(int number)
        {
            if (number == 0)
                return new int[] { 0 };

            List<int> binary = new List<int>();

            while (number > 0)
            {
                binary.Add(number % 2);
                number /= 2;
            }

            binary.Reverse(); // To get MSB → LSB
            return binary.ToArray();
        }

        static void Main(string[] args)
        {
            int input = 1002;
            int[] output = DecimalToBinaryArray(input);

                Console.WriteLine("Input is: " + input);
            if(input < 0)
            {
                Console.WriteLine("Output is: [ -1 ]");
            }
            else
            {
                Console.WriteLine("Output is: [ " + string.Join(',', output) + "]");
            }
        }
    }
}
namespace ProductOfDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 56;
            int output = 0;  

            if(input < 0)
            {
                output = -1;
            }
            else if(input % 3 == 0 || input % 5 == 0) 
            {
                output = -2;
            }
            else
            {
                int product = 1;

                int temp = input;

                while (temp > 0)
                {
                    int a = temp % 10;
                    product *= a;
                    temp /= 10;
                }

                if (product % 3 == 0 || product % 5 == 0)
                {
                    output = 1;
                }
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Ouput is: " + output);

        }
    }
}

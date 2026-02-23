namespace ConvertBinaryToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 1001;
            int output = 0;

            bool isBinary = true;

            int temp = input;

            while (temp > 0)
            {
                if (temp % 10 != 0 || temp % 10 != 1)
                {
                    isBinary = false;
                    break;
                }
                else
                {
                    temp /= 10;
                }
            }

            if (isBinary)
            {
                output = -1;
            }
            else if (input > 11111)
            {
                output = -2;
            }
            else
            {
                // convert 
                int ans = 0;

                temp = input;

                int a = 0;
                while (temp > 0)
                {
                    double pow = Math.Pow(2, a++);
                    ans += (int)(pow * (temp % 10));

                    temp /= 10;
                }

                output = ans;
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}
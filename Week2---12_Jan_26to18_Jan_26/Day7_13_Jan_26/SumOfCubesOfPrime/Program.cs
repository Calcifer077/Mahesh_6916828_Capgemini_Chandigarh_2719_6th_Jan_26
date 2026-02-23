namespace SumOfCubesOfPrime
{
    internal class Program
    {
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public long SumOfCubesOfPrimes(int n)
        {
            long sum = 0;
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    sum += Convert.ToInt64(i * i * i);
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int input = 45;
            long output = 0;

            Program obj = new Program();

            if (input < 0)
            {
                output = -1;
            }
            else if (input > 32767)
            {
                output = -2;
            }
            else
            {
                output = obj.SumOfCubesOfPrimes(input);
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}
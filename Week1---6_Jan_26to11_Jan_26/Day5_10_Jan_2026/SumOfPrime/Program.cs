namespace SumOfPrime
{
    internal class Program
    {

        public bool IsPrime(int number)
        {
            if (number <= 1) return false; // 1 and below are not prime
            if (number == 2) return true;  // 2 is the only even prime
            if (number % 2 == 0) return false; // Other even numbers are not prime

            // Only need to check for divisors up to the square root of the number
            var boundary = (int)Math.Floor(Math.Sqrt(number));

            // Check odd divisors starting from 3
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false; // Found a divisor, not prime
                }
            }

            return true; // No divisors found, the number is prime
        }
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 3, 4, 5 };
            int output = 0;

            Program obj = new Program();

            bool hasNegative = false;
            foreach (int i in input)
            {
                if (i < 0)
                {
                    hasNegative = true;
                    break;
                }
            }

            if (hasNegative)
            {
                output = -1;
            }
            else if (input.Length < 0)
            {
                output = -2;
            }
            else
            {
                int sum = 0;
                foreach (int i in input)
                {
                    if (obj.IsPrime(i))
                    {
                        sum += i;
                    }
                }

                if (sum > 0)
                {
                    output = sum;
                }
                else
                {
                    output = -3;
                }
            }

            Console.Write("Input is: ");
            Console.WriteLine("[" + string.Join(", ", input) + "]");

            Console.WriteLine("Output is: " + output);
        }
    }
}
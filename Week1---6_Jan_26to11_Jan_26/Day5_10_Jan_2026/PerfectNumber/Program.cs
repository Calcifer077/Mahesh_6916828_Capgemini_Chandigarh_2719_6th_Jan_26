namespace PerfectNumber
{
    internal class Program {
        // Method to check if a number is perfect
        public bool IsPerfect(int number)
        {
            // 1. A perfect number must be a positive integer.
            if (number <= 0)
            {
                return false;
            }

            int sumOfDivisors = 0;

            // 2. Iterate from 1 up to (but not including) the number
            // to find all proper positive divisors.
            for (int i = 1; i < number; i++)
            {
                // 3. Check if 'i' is a divisor of 'number'
                if (number % i == 0)
                {
                    sumOfDivisors += i;
                }
            }

            // 4. If the sum of the divisors equals the number, it is perfect.
            return sumOfDivisors == number;
        }

        static void Main(string[] args) {
            int input = 6;
            int output = 0;

            Program obj = new Program();

            if (obj.IsPerfect(input)){
                output = 1;
            }else if(!(input < 0))
            {
                output = -1;
            }
            else
            {
                output = -2;
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }
}
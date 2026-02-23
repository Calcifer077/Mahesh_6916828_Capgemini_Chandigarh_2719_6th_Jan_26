namespace HowManyTimesRepeating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 1, 2, 2, 3, 3 };
            int input2 = 5;
            int input3 = 2;

            int output = 0;

            bool hasNegative = false;

            foreach (int i in input1) { 
                if(i < 0)
                {
                    hasNegative = true;
                    break;
                }
            }

            if (hasNegative)
            {
                output = -1;
            }
            else if (input2 < 0)
            {
                output = -2;
            }
            else if (input3 < 0)
            {
                output = -3;
            }
            else
            {
                int count = 0;
                foreach (int i in input1)
                {
                    if (i == input3)
                    {
                        count++;
                    }
                }
                output = count;
            }

            Console.WriteLine("Input is: [" + string.Join(',', input1) + "]");
            Console.WriteLine("Output is: " + output);
        }
    }
}
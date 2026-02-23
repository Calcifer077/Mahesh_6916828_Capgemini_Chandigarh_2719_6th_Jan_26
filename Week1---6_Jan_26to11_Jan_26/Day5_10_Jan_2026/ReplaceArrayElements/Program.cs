namespace ReplaceArrayElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 12, 34, 56, 17, 2 };
            int input2 = 5;

            int[] output = new int[input2];

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
                output[0] = -1;
            }
            else if (input2 < 0)
            {
                output[0] = -2;
            }else if(input2 % 2 == 0)
            {
                output[0] = -3;
            }
            else
            {
                Array.Reverse(input1);

                for(int i = 0; i < input2; i++)
                {
                    output[i] = input1[i];
                }
            }

            Console.Write("Input is: ");
            Console.WriteLine("[" + string.Join(',', input1) + "]");
            Console.WriteLine("Output is : [" + string.Join(',', output) + "]");

        }
    }
}
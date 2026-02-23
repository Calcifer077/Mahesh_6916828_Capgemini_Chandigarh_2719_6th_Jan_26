namespace SearchAndRemove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 54, 26, 78, 32, 55, 78, 78,78,78 };
            int input2 = input1.Length;
            int input3 = 78;

            int[] output = new int[1];

            bool hasNegative = false;

            foreach (int i in input1)
            {
                if (i < 0)
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
            }
            else
            {
                int index = Array.IndexOf(input1, input3);

                if (index == -1)
                {
                    output[0] = -3;
                }
                else
                {
                    int elCount = 0;
                    foreach (int i in input1)
                    {
                        if (i == input3) elCount++;
                    }


                    output = new int[input2 - elCount];
                    int j = 0;

                    foreach (int i in input1)
                    {
                        if (i != input3)
                        {
                            output[j++] = i;
                        }
                    }

                    Array.Sort(output);
                }
            }

            Console.WriteLine("Input array is : [" + string.Join(',', input1) + "] and to be searched element is : " + input3);
            Console.WriteLine("Output is: [" + string.Join(',', output) + "]");
        }
    }
}
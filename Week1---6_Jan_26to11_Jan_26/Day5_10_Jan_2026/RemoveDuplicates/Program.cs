namespace RemoveDuplicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 2, 3, 3, };
            int size = input.Length;
            int[] output = new int[1];

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
                output[0] = -1;
            }
            else if (size < 0)
            {
                output[0] = -2;
            }
            else
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();

                foreach(int i in input)
                {
                    if (dict.ContainsKey(i))
                    {
                        dict[i] += 1;
                    }
                    else
                    {
                        dict[i] = 1;
                    }
                }

                size = dict.Count;
                output = new int[size];

                int j = 0;
                foreach(int i in dict.Keys)
                {
                    output[j++] = i;
                }
            }

            Console.Write("Input is: ");
            Console.WriteLine("[" + string.Join(',', input) + "]");
            Console.WriteLine("Output is : [" + string.Join(',', output) + "]");


        }
    }
}
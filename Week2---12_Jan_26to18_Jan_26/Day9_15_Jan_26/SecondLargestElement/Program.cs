namespace SecondLargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1,2,2,2,2,2 };

            int output = 0;

            if (input.Length < 0)
            {
                output = -2;
            }
            else
            {
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
                else
                {
                    int larg = 0;
                    int seclarg = 0;

                    foreach (int i in input)
                    {
                        if(i > larg)
                        {
                            seclarg = larg;
                            larg = i;
                        }else if(i > seclarg && i < larg)
                        {
                            seclarg = i;
                        }
                    }

                    output = seclarg;
                }

                Console.WriteLine("Input is: [" + string.Join(',', input) + "]");
                Console.WriteLine("Output is: " + output);
            }
        }
    }
}
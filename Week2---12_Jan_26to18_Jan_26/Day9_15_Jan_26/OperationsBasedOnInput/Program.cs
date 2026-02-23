namespace OperationsBasedOnInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1 = 10, input2 = 20, input3 = 3;

            int output = 0;

            if (input1 < 0 && input2 < 0)
            {
                output = -1;
            }
            else
            {
                switch (input3)
                {
                    case 1:
                        {
                            output = input1 + input2;
                            break;
                        }
                    case 2:
                        {
                            output = input1 - input2; break;
                        }

                    case 3:
                        {
                            output = input1 * input2;
                            break;
                        }
                    case 4:
                        {
                            output = input1 / input2;
                            break;
                        }
                }
            }

            Console.WriteLine("Input 1 - " + input1 + " Input 2 - " + input2 + " Input 3 - " + input3);
            Console.WriteLine("Output is " + output);
        }
    }
}

namespace InsertElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 2, 4, 1, 4, 8 };
            int el = 8;
            int[] output = new int[input.Length + 1];

            bool hasneg = false;

            foreach (int i in input)
            {

                if (i < 0)
                {
                    hasneg = true;
                    break;
                }
            }

            if (hasneg)
            {
                output[0] = -1;
            }
            else if (input.Length < 0)
            {
                output[0] = -2;
            }
            else
            {
                output[input.Length] = el;

                for (int i = 0; i < input.Length; i++)
                {
                    output[i] = input[i];
                }

                Array.Sort(output);
            }

            Console.WriteLine("Input is: [" + string.Join(',', input) + "] and the element to insert is " + el);
            Console.WriteLine("Output is: [" + string.Join(',', output) + "]");
        }
    }
}
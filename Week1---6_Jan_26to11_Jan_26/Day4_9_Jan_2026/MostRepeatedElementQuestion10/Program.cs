namespace MostRepeatedElementQuestion10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = { 2, 2, 2, 2, 3, 3, 3, 3, 4 };

            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int i in inputArray) {
                if (dict.ContainsKey(i))
                {
                    dict[i] += 1;
                    //dict.Add(i, dict[i] + 1);
                }
                else
                {
                    dict.Add(i, 1);
                }
            }


            int maxValue = 0;
            foreach(var el in dict.Keys)
            {
                maxValue = Math.Max(maxValue, dict[el]);
            }

            Console.WriteLine("Input is: [" + string.Join(',', inputArray) + "]");
            Console.Write("Output is: {");
            foreach (var el in dict.Keys)
            {
                if (dict[el] == maxValue) {
                    Console.Write(el + " ");
                }
            }
            Console.Write("}");
        }
    }
}

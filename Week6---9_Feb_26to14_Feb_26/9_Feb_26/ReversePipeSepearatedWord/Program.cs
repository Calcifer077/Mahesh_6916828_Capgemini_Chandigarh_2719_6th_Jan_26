namespace ReversePipeSepearatedWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "hello|this|is|a|test";
            List<string> output = new List<string>();

            List<string> test = new List<string>();
            string temp = "";
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == '|')
                {
                    test.Add(temp);
                    temp = "";
                }
                else
                {
                    temp += input[i];
                }
            }

            test.Add(temp);

            for(int i = test.Count - 1; i >= 0; i--)
            {
                output.Add(test[i]);
            }

            for(int i = 0; i < output.Count; i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
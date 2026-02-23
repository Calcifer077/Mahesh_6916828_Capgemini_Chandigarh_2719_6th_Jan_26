namespace ReplaceFirstOccurance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "I love programming.";
            char torepalce = '.';

            int idx = input.IndexOf(torepalce);

            string output = input.Substring(0, idx) + "!" + input.Substring(idx + 1);
            Console.WriteLine(output);
        }
    }
}
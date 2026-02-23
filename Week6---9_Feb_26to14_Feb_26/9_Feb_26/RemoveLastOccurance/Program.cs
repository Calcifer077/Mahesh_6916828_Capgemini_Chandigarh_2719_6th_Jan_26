namespace RemoveLastOccurance
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string input = "I am a programmer. I learn at Codeforwin.";
            string word = "Codeforwin";

            // arguments -> starting index, ending index.
            string output = input.Remove(input.LastIndexOf(word), word.Length);
            Console.WriteLine(output);
        }
    }
}

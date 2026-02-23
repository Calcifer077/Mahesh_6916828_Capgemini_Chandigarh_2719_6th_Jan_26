namespace DeleteAlternatingCharacters;

internal class Program{
    static void Main(string[] args)
    {
        string input = "abcdef";
        string output = "";

        for(int i = 0; i< input.Length; i++)
        {
            if(i % 2 == 0)
            {
                output += input[i];
            }   
        }

        Console.WriteLine(output);
    }
}
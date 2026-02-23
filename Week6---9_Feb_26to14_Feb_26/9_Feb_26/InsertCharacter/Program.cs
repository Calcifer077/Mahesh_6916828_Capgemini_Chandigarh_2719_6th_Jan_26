namespace InsertCharacter;

internal class Program{
    static void Main(string[] args)
    {
        string input = "Hello World";
        int index = 3;
        char character = 'a';

        // Console.WriteLine(input[..(index - 1)] + character + input.Substring(index -1));
        Console.WriteLine(input[..(index - 1)] + character + input[(index - 1)..]);
    }
}
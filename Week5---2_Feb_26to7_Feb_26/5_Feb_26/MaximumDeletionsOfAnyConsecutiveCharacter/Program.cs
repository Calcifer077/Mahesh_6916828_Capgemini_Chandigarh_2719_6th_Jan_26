namespace MaximumDelettionsOfAnyConsecutiveCharacter;

internal class Program
{
    static void Main(string[] args)
    {
        string s = "aabbcc";

        int output = 0;
        int count = 1;
        for(int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                output += count / 2;
                count = 1;
            }
        }   

        output += count / 2;

        Console.WriteLine(output);
    }
}
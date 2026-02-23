using System;

namespace InsertSubstring;

class Program
{
    static string InsertSubstring(string original, string toInsert, int position)
    {
        // Validate position
        if (position < 0 || position > original.Length)
        {
            throw new ArgumentOutOfRangeException("position");
        }

        // Insert substring
        string result = original.Substring(0, position) 
                        + toInsert 
                        + original.Substring(position);

        return result;
    }

    static void Main()
    {
        string original = "C programming";
        string insert = "ABC";
        int position = 3;

        string output = InsertSubstring(original, insert, position);
        Console.WriteLine(output);
    }
}
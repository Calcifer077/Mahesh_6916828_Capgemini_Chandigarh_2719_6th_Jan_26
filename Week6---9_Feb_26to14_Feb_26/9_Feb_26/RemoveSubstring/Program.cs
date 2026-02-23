using System;

namespace RemoveSubstring;

class Program
{
    static string ReplaceSubstring(string original, string toRemove, string toInsert, int position)
    {
        // Validate position
        if (position < 0 || position + toRemove.Length > original.Length)
        {
            throw new ArgumentOutOfRangeException("position");
        }

        // Remove the substring
        string result = original.Remove(position, toRemove.Length);

        // Insert the new substring at same position
        result = result.Insert(position, toInsert);

        return result;
    }

    static void Main()
    {
        string original = "HelloWorld";
        string toRemove = "World";
        string toInsert = "Universe";
        int position = 5;

        string output = ReplaceSubstring(original, toRemove, toInsert, position);
        Console.WriteLine(output);
    }
}
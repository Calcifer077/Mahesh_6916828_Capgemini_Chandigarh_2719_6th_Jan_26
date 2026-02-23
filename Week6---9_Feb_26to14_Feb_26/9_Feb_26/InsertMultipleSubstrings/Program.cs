using System;
using System.Collections.Generic;

namespace InsertMultipleSubstrings;

class Program
{
    static string InsertMultiple(string original, List<(string text, int position)> inserts)
    {
        // Sort inserts by position in descending order
        inserts.Sort((a, b) => b.position.CompareTo(a.position));

        foreach (var item in inserts)
        {
            if (item.position < 0 || item.position > original.Length)
                throw new ArgumentOutOfRangeException("position");

            original = original.Insert(item.position, item.text);
        }

        return original;
    }

    static void Main()
    {
        string original = "ABCDEF";

        var inserts = new List<(string, int)>
        {
            ("Hello", 0),
            ("World", 5),
            ("!", original.Length)
        };

        string result = InsertMultiple(original, inserts);
        Console.WriteLine(result);
    }
}
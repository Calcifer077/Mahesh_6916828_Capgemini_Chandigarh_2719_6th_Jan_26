using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = "hello|world|test";

        string result = string.Join("|",
            input.Split('|')
                 .Select(w => w.Trim())
                 .OrderBy(w => w));

        Console.WriteLine("Sorted output:");
        Console.WriteLine(result);
    }
}
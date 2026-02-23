using System;

class Program
{
    static void Main()
    {
        string s = "beautiful";

        int deletions = CountVowelPairDeletions(s);
        Console.WriteLine("Number of deletions: " + deletions);
    }

    static bool IsVowel(char c)
    {
        return "aeiou".Contains(c);
    }

    static int CountVowelPairDeletions(string s)
    {
        int count = 0;

        for (int i = 0; i < s.Length - 1;)
        {
            if (IsVowel(s[i]) && IsVowel(s[i + 1]))
            {
                count++;
                i += 2; // skip the pair (deleted)
            }
            else
            {
                i++;
            }
        }

        return count;
    }
}
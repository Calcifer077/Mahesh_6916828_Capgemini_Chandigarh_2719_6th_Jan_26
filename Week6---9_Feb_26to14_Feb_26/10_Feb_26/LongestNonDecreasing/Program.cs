using System;

namespace LongestNonDecreasing;

internal class Solution
{
    public static int LongestNonDecreasingSubstring(string s)
    {
        int n = s.Length;
        int zeros = 0, ones = 0;

        // Process all swappable pairs
        for (int i = 0; i + 1 < n; i += 2)
        {
            if (s[i] == '0') zeros++;
            else ones++;

            if (s[i + 1] == '0') zeros++;
            else ones++;
        }

        // If length is odd, last character is fixed
        if (n % 2 == 1)
        {
            char last = s[n - 1];
            if (last == '0')
                zeros++;
            else
                ones++;
        }

        // We can arrange all zeros before all ones
        return zeros + ones;
    }

    static void Main()
    {
        string s = "1100101";
        Console.WriteLine(LongestNonDecreasingSubstring(s));
    }
}

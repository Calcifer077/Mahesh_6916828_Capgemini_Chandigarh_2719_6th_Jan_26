using System;

class Program
{
    static void Main()
    {
        string s = "abccba";

        int maxLen = LongestPalindromeLength(s);
        Console.WriteLine("Length of longest palindromic substring: " + maxLen);
    }

    static int LongestPalindromeLength(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        int maxLength = 1;

        for (int i = 0; i < s.Length; i++)
        {
            // Odd length palindrome
            maxLength = Math.Max(maxLength, ExpandFromCenter(s, i, i));

            // Even length palindrome
            maxLength = Math.Max(maxLength, ExpandFromCenter(s, i, i + 1));
        }

        return maxLength;
    }

    static int ExpandFromCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }

        return right - left - 1;
    }
}
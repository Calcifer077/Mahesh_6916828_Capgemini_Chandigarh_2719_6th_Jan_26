namespace ScoreOfString;

internal class Program
{
    public static int CalculateScore(string str)
    {
        int score = 0;

        // Check palindromes of length 4
        for (int i = 0; i <= str.Length - 4; i++)
        {
            if (IsPalindrome(str, i, 4))
            {
                score += 5;
            }
        }

        // Check palindromes of length 5
        for (int i = 0; i <= str.Length - 5; i++)
        {
            if (IsPalindrome(str, i, 5))
            {
                score += 10;
            }
        }

        return score;
    }

    public static bool IsPalindrome(string str, int start, int length)
    {
        int left = start;
        int right = start + length - 1;

        while (left < right)
        {
            if (str[left] != str[right])
                return false;

            left++;
            right--;
        }

        return true;
    }

    static void Main(string[] args)
    {
        string input = "ABCBAAAA";

        int output = CalculateScore(input);

        Console.WriteLine(output);

    }
}
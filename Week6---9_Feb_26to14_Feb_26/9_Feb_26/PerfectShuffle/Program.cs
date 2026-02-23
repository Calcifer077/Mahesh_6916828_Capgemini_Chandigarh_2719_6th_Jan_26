using System;

class Program
{
    static bool IsPerfectShuffle(string x, string y, string z)
    {
        int m = x.Length;
        int n = y.Length;

        // Length check
        if (m + n != z.Length)
            return false;

        bool[,] dp = new bool[m + 1, n + 1];
        dp[0, 0] = true;

        // Fill first column
        for (int i = 1; i <= m; i++)
            dp[i, 0] = dp[i - 1, 0] && x[i - 1] == z[i - 1];

        // Fill first row
        for (int j = 1; j <= n; j++)
            dp[0, j] = dp[0, j - 1] && y[j - 1] == z[j - 1];

        // Fill rest of table
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                dp[i, j] =
                    (dp[i - 1, j] && x[i - 1] == z[i + j - 1]) ||
                    (dp[i, j - 1] && y[j - 1] == z[i + j - 1]);
            }
        }

        return dp[m, n];
    }

    static void Main()
    {
        string x = "abc";
        string y = "def";
        string z = "abcdef";

        Console.WriteLine(IsPerfectShuffle(x, y, z)
            ? "Perfect Shuffle"
            : "Not a Perfect Shuffle");
    }
}
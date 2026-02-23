using System;

class Program
{
    static void Main()
    {
        int N = 3;
        string[] input = {"the quick brown fox", "king of kings", "hello world"};

        for (int i = 0; i < N; i++)
        {
            string line = input[i];

            int posThe = line.IndexOf("the");
            int posOf = line.IndexOf("of");

            if (posThe == -1 && posOf == -1)
            {
                Console.WriteLine("-1");
            }
            else
            {
                Console.WriteLine($"{posThe} {posOf}");
            }
        }
    }
}
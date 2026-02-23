using System;

namespace ValidWords;

internal class Program{

public static int CountValidWords(string input)
{
    string vowels = "aeiouAEIOU";
    int validCount = 0;

    string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    foreach (string word in words)
    {
        if (word.Length <= 2)
            continue;

        bool hasVowel = false;
        bool hasConsonant = false;
        bool isValid = true;

        foreach (char c in word)
        {
            if (!char.IsLetterOrDigit(c))
            {
                isValid = false;
                break;
            }

            if (char.IsLetter(c))
            {
                if (vowels.Contains(c))
                    hasVowel = true;
                else
                    hasConsonant = true;
            }
        }

        if (isValid && hasVowel && hasConsonant)
            validCount++;
    }

    return validCount;
}

public static void Main(string[] args){
    string input = "Hello a1b sky@ abc 12a";

    Console.WriteLine(CountValidWords(input));


}

}
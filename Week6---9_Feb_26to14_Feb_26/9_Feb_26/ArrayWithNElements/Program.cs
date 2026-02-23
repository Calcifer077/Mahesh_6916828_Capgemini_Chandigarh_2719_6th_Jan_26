using System;

class Program
{
    static void Main()
    {
        int N = 5;
        int[] arr = {2,3,4,9,8};

        int count = 0;

        for (int i = 0; i < N; i++)
        {
            bool found = false;

            for (int j = i + 1; j < N; j++)
            {
                if (arr[j] > arr[i] && arr[j] % arr[i] == 0)
                {
                    found = true;
                    break; // only need the next such element
                }
            }

            if (found)
                count++;
        }

        Console.WriteLine(count);
    }
}
namespace Triplets;

internal class Program{

public static int CountDivisibleTriplets(int[] arr, int d)
{
    int n = arr.Length;
    int count = 0;

    for (int i = 0; i < n - 2; i++)
    {
        int[] freq = new int[d];

        for (int j = i + 1; j < n; j++)
        {
            int currentMod = (arr[i] + arr[j]) % d;
            int needed = (d - currentMod) % d;

            count += freq[needed];

            freq[arr[j] % d]++;
        }
    }

    return count;
}
public static void Main(string[] args){

}

}
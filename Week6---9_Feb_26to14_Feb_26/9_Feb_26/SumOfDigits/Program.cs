namespace SumOfDigits;

internal class Program{
    static void Main(string[] args)
    {

        int input = 2785;
        int output = 0;

        while(input > 0)
        {
int temp = input % 10;
output += temp;
input /= 10;
        }

        Console.WriteLine(output);
    }
}
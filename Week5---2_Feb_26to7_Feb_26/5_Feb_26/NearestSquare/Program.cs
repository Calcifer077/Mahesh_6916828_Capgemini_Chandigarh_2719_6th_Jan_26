namespace NearestSquare;

internal class Program{
    public static bool check(long a)
    {
        for(long i = 1; i < a; i++)
        {
            if(i * i == a) return true;
        }

        return false;
    }

    static void Main(string[] args)
    {
        long input = 18;
        long output = 0;

        long pos = input + 1;
        long neg = input - 1;

        while (true)
        {
            if (check(pos))
            {
                output = pos;
                break;
            }
            else
            {
                pos++;
            }

            if(neg > 0)
            {
                if(check(neg))
                {
                    output = neg;
                    break;
                }
                else
                {
                    neg--;
                }
            }
        }

        Console.WriteLine(output);
    }
}
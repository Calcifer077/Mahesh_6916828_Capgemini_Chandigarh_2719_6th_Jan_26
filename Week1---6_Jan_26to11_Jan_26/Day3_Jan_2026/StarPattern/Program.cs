namespace StarPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x;
            Console.WriteLine("Enter the number of stars you want in first row:");
            x = int.Parse(Console.ReadLine());

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x - i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}

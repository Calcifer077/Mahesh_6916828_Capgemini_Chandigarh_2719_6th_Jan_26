namespace GreatestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y, z;

            Console.WriteLine("Enter value of x: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of y: ");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of z: ");
            z = int.Parse(Console.ReadLine());

            if (x > y && x > z)
            {
                Console.WriteLine(x + " is the greatest.");
            }
            else if (y > z && y > x)
            {
                Console.WriteLine(y + " is the greatest.");
            }
            else
            {
                Console.WriteLine(z + " is the greatest.");
            }
        }
    }
}

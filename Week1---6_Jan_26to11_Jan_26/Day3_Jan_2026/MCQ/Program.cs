namespace MCQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the correct way to declare a variable to store an integer in csharp?");
            Console.WriteLine("a. int 1x = 10;");
            Console.WriteLine("b. int x = 10;");
            Console.WriteLine("c. float x = 10.0f;");
            Console.WriteLine("d. string x = " + 10 + ";");
            String choice;
            Console.Write("Choose the correct answer:");
            choice = Console.ReadLine();

            if (choice == "b")
            {
                Console.WriteLine("Correct Answer");
            }
            else
            {
                Console.WriteLine("Incorrect Answer");
            }
        }
    }
}

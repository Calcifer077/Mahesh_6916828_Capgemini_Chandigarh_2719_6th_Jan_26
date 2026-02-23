namespace StudentGrade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int percentage;
            Console.WriteLine("Enter the percentage of your student");
            percentage = int.Parse(Console.ReadLine());

            if (percentage >= 90)
            {
                Console.WriteLine("Grade A");
            }
            else if (percentage >= 80)
            {
                Console.WriteLine("Grade B");
            }
            else if (percentage >= 70)
            {
                Console.WriteLine("Grade C");
            }
            else if (percentage >= 60)
            {
                Console.WriteLine("Grade D");
            }
            else if (percentage >= 50)
            {
                Console.WriteLine("Grade E");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}

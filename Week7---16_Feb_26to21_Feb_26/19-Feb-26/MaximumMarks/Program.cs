using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter no of semester:");
        int semesters = int.Parse(Console.ReadLine());

        int[] subjects = new int[semesters];

        // Input number of subjects per semester
        for (int i = 0; i < semesters; i++)
        {
            Console.Write($"Enter no of subjects in {i + 1} semester:");
            subjects[i] = int.Parse(Console.ReadLine());
        }

        // Process each semester
        for (int i = 0; i < semesters; i++)
        {
            Console.Write($"Marks obtained in semester {i + 1}:");

            int max = int.MinValue;

            for (int j = 0; j < subjects[i]; j++)
            {
                int mark = int.Parse(Console.ReadLine());

                if (mark < 0 || mark > 100)
                {
                    Console.WriteLine("You have entered invalid mark.");
                    return;
                }

                if (mark > max)
                    max = mark;
            }

            Console.WriteLine($"Maximum mark in {i + 1} semester:{max}");
        }
    }
}

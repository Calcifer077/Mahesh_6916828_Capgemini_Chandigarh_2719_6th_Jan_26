using System;
using System.Collections.Generic;
using System.Text;

namespace FootballerProj
{
    internal class Footballer_V1
    {
        string name;
        string position;
        int height;
        int weight;
        int age;
        string[] teams;
        int[] goals;

        static int countPlayers;

        // static constructors
        static Footballer_V1()
        {
            countPlayers = 0;
        }

        // default constructor
        public Footballer_V1()
        {
            countPlayers++;
            Console.Write("Enter name: ");
            this.name = Console.ReadLine();

            Console.Write("Enter position: ");
            this.position = Console.ReadLine();

            Console.Write("Enter height: ");
            this.height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter weight: ");
            this.weight = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter age: ");
            this.age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the number of teams player have played for: ");
            int numTeams = Convert.ToInt32(Console.ReadLine());

            this.teams = new string[numTeams];
            this.goals = new int[numTeams];

            Console.WriteLine("Enter the name of each team one by one: ");
            for (int i = 0; i < numTeams; i++)
            {
                this.teams[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of goals scored by player for each team one by one: ");
            for (int i = 0; i < numTeams; i++)
            {
                this.goals[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DisplayFootballeData()
        {
            Console.WriteLine("Name of the player: " + this.name);

            Console.WriteLine("Position of the player: " + this.position);

            Console.WriteLine("Height of the player: " + this.height);

            Console.WriteLine("Weight of the player: " + this.weight);

            Console.WriteLine("Age of the player: " + this.age);

            Console.WriteLine("Teams of the player and goals for each player: ");
            for (int i = 0; i < this.teams.Length; i++)
            {
                Console.WriteLine(this.teams[i] + " -> " + this.goals[i]);
            }

            Console.WriteLine("Total number of players present: " + countPlayers);
        }

        public void Run()
        {
            Console.WriteLine(this.name + " is running");
        }

        public void Jump()
        {
            Console.WriteLine(this.name + " is jumping");
        }

        public void Kick()
        {
            Console.WriteLine(this.name + " kicked the ball");
        }

        public void Score()
        {
            Console.WriteLine(this.name + " scored a goal");
        }

        public void Penalty()
        {
            Console.WriteLine(this.name + " took a penalty");
        }

        public void Freekick()
        {
            Console.WriteLine(this.name + " took a freekick");
        }
    }
}

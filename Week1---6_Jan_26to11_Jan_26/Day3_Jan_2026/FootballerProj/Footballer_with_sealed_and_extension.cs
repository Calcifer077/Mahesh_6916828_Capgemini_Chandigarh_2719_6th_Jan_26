using System;
using System.Collections.Generic;
using System.Text;

namespace FootballerProj
{

    interface Club_with_sealed_extension
    {
        string clubName { get; set; }
        string clubCountry { get; set; }
        string[] clubTournaments { get; set; }
        string clubColorCode { get; set; }
        int clubTotalPlayers { get; set; }
    }

    interface National_team_with_sealed_extension
    {
        string nationalName { get; set; }
        string nationalCountry { get; set; }
        string nationalColorCode { get; set; }
        string[] nationalTournaments { get; set; }
        int nationalTotalPlayers { get; set; }
    }

    internal sealed class Footballer_with_sealed_extension : Club_with_two_interface, National_team_with_two_interface
    {
        public string clubName { get; set; }
        public string clubCountry { get; set; }
        public string[] clubTournaments { get; set; }
        public string clubColorCode { get; set; }
        public int clubTotalPlayers { get; set; }

        public string nationalName { get; set; }
        public string nationalCountry { get; set; }
        public string nationalColorCode { get; set; }
        public string[] nationalTournaments { get; set; }
        public int nationalTotalPlayers { get; set; }

        public Footballer_with_sealed_extension(string clubName, string clubCountry, string[] clubTournaments, string clubColorCode, int clubTotalPlayers, string nationalName, string nationalCountry, string nationalColorCode, string[] nationalTournaments, int nationalTotalPlayers)
        {
            this.clubName = clubName;
            this.clubCountry = clubCountry;
            this.clubTournaments = clubTournaments;
            this.clubColorCode = clubColorCode;
            this.clubTotalPlayers = clubTotalPlayers;
            this.nationalName = nationalName;
            this.nationalCountry = nationalCountry;
            this.nationalColorCode = nationalColorCode;
            this.nationalTournaments = nationalTournaments;
            this.nationalTotalPlayers = nationalTotalPlayers;
        }

        public void DispData()
        {
            Console.WriteLine("Club: " + clubName + " " + clubCountry);
            Console.WriteLine("National Team: " + nationalName + " " + nationalCountry);
        }
    }

    static class FootballerExtensions
    {
        public static void DisplayFullInfo(this Footballer_with_sealed_extension footballer)
        {
            Console.WriteLine("----- Club Information -----");
            Console.WriteLine($"Name: {footballer.clubName}");
            Console.WriteLine($"Country: {footballer.clubCountry}");
            Console.WriteLine($"Color Code: {footballer.clubColorCode}");
            Console.WriteLine($"Total Players: {footballer.clubTotalPlayers}");
            Console.WriteLine("Tournaments: " + string.Join(", ", footballer.clubTournaments));

            Console.WriteLine("\n----- National Team Information -----");
            Console.WriteLine($"Name: {footballer.nationalName}");
            Console.WriteLine($"Country: {footballer.nationalCountry}");
            Console.WriteLine($"Color Code: {footballer.nationalColorCode}");
            Console.WriteLine($"Total Players: {footballer.nationalTotalPlayers}");
            Console.WriteLine("Tournaments: " + string.Join(", ", footballer.nationalTournaments));
        }
    }
}

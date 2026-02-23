using System;
using System.Collections.Generic;
using System.Text;

namespace FootballerProj
{

    interface Club_with_two_interface
    {
        string clubName { get; set; }
        string clubCountry { get; set; }
        string[] clubTournaments { get; set; }
        string clubColorCode { get; set; }
        int clubTotalPlayers { get; set; }
    }

    interface National_team_with_two_interface
    {
        string nationalName { get; set; }
        string nationalCountry { get; set; }
        string nationalColorCode { get; set; }
        string[] nationalTournaments { get; set; }
        int nationalTotalPlayers { get; set; }
    }

    internal class Footballer_with_two_interface : Club_with_two_interface, National_team_with_two_interface
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

        public Footballer_with_two_interface(string clubName, string clubCountry, string[] clubTournaments, string clubColorCode, int clubTotalPlayers, string nationalName, string nationalCountry, string nationalColorCode, string[] nationalTournaments, int nationalTotalPlayers)
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
}

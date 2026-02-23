using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballerProj
{
    // --- INTERFACES ---
    interface IClubCrud
    {
        string clubName { get; set; }
        string clubCountry { get; set; }
        string[] clubTournaments { get; set; }
        string clubColorCode { get; set; }
        int clubTotalPlayers { get; set; }
    }

    interface INationalTeamCrud
    {
        string nationalName { get; set; }
        string nationalCountry { get; set; }
        string nationalColorCode { get; set; }
        string[] nationalTournaments { get; set; }
        int nationalTotalPlayers { get; set; }
    }

    // --- MODEL ---
    internal class FootballerCrud : IClubCrud, INationalTeamCrud
    {
        public int Id { get; set; } // Added for easier CRUD tracking
        public string Name { get; set; } // The player's name

        // IClub Implementation
        public string clubName { get; set; }
        public string clubCountry { get; set; }
        public string[] clubTournaments { get; set; }
        public string clubColorCode { get; set; }
        public int clubTotalPlayers { get; set; }

        // INationalTeam Implementation
        public string nationalName { get; set; }
        public string nationalCountry { get; set; }
        public string nationalColorCode { get; set; }
        public string[] nationalTournaments { get; set; }
        public int nationalTotalPlayers { get; set; }

        public FootballerCrud(int id, string name, string clubName, string nationalName)
        {
            Id = id;
            Name = name;
            this.clubName = clubName;
            this.nationalName = nationalName;
            // Simplifying arrays for this example
            clubTournaments = new string[] { "League" };
            nationalTournaments = new string[] { "World Cup" };
        }

        public void DispData()
        {
            Console.WriteLine($"[{Id}] Player: {Name} | Club: {clubName} | National: {nationalName}");
        }
    }
}
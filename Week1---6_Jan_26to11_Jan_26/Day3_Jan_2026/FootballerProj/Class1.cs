using System;
using System.Collections.Generic;
using System.Text;

namespace FootballerProj
{
    public abstract class Team1
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string ColorCode { get; set; }
        public int TotalPlayers { get; set; }
        public List<string> Tournaments { get; set; } = new List<string>();
    }

    public class Club1 : Team1
    {
        // only club specific things
        public string StadiumName { get; set; }
    }

    public class NationalTeam1 : Team1
    {
        // only national specific things
        public string Region { get; set; }
    }

    public class Player1
    {
        public string PlayerName { get; set; }

        // This is "Composition" - The player HAS these teams
        public Club1 MyClub { get; set; }
        public NationalTeam1 MyNationalTeam { get; set; }

        public Player1(string name, Club1 club, NationalTeam1 national)
        {
            PlayerName = name;
            MyClub = club;
            MyNationalTeam = national;
        }
    }

}

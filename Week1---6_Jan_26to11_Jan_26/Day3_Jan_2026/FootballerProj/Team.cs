using System;

namespace FootballerProj
{
    public abstract class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string ColorCode { get; set; }
        public int TotalPlayers { get; set; }
        public string[] Tournaments { get; set; }

        public Team(string name, string country, string type, string colorCode, int totalPlayers, string[] tournaments)
        {
            Name = name;
            Country = country;
            Type = type;
            ColorCode = colorCode;
            TotalPlayers = totalPlayers;
            Tournaments = tournaments;
        }
    }

    public class Club : Team
    {
        // only club specific things
        public string StadiumName { get; set; }

        public Club(string Name, string Country, string Type, string ColorCode, int TotalPlayers, string[] Tournaments, string StadiumName) : base(Name, Country, Type, ColorCode, TotalPlayers, Tournaments)
        {

            this.StadiumName = StadiumName;
        }
    }

    public class NationalTeam : Team
    {
        // only national specific things
        public string Region { get; set; }

        public NationalTeam(string Name, string Country, string Type, string ColorCode, int TotalPlayers, string[] Tournaments, string Region) : base(Name, Country, Type, ColorCode, TotalPlayers, Tournaments)
        {

            this.Region = Region;
        }
    }

    public class Player
    {
        public string PlayerName { get; set; }

        // players club and national team
        public Club MyClub { get; set; }
        public NationalTeam MyNationalTeam { get; set; }

        public Player(string name, Club club, NationalTeam national)
        {
            PlayerName = name;
            MyClub = club;
            MyNationalTeam = national;
        }
    }

}

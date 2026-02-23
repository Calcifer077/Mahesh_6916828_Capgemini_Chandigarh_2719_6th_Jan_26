using System;
using System.Collections.Generic;
using System.Text;

namespace FootballerProj
{
    enum CountryEnum
    {
        Spain,
        Portugal,
        England,
        Italy,
        Argentina,
        Brazil,
        Denmark,
        Wales,
        Russia,
        India,
        South_Korea,
        Japan,
        France
    }

    enum ClubEnum
    {
        Real_Madrid,
        Barcelona,
        Juventus,
        Manchester_United,
        Manchester_City,
        Arsenal,
        Sporting_FC,
        FC_Porto,
        Bengaluru_FC,
        Mohan_Bagan_FC,
        Atletico_Madrid,
        PSG,
        Lillie,
        AC_Milan,
        Inter_Milan,
    }

    enum ColorCodeEnum
    {
        White,
        Black,
        Red,
        Gray,
        White_Golden,
        Red_Purple,
        Black_White,
        Red_Black,
        Blue_Black,
        Purple,
        Sky_Blue,
        Light_Blue_White
    }

    interface Club_with_struct
    {
        string clubName { get; set; }
        string clubCountry { get; set; }
        string[] clubTournaments { get; set; }
        string clubColorCode { get; set; }
        int clubTotalPlayers { get; set; }
    }

    interface National_team_with_struct
    {
        string nationalName { get; set; }
        string nationalCountry { get; set; }
        string nationalColorCode { get; set; }
        string[] nationalTournaments { get; set; }
        int nationalTotalPlayers { get; set; }
    }

    internal class Footballer_with_struct_and_enum: Club_with_struct, National_team_with_struct
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

        public Footballer_with_struct_and_enum(string clubName, string clubCountry, string[] clubTournaments, string clubColorCode, int clubTotalPlayers, string nationalName, string nationalCountry, string nationalColorCode, string[] nationalTournaments, int nationalTotalPlayers)
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

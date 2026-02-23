using System;
using System.Collections.Generic;
using System.Text;

namespace FootballerProj
{
    enum CountryEnumEH
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

    enum ClubEnumEH
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

    enum ColorCodeEnumEH
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

    interface Club_with_EH
    {
        string clubName { get; set; }
        string clubCountry { get; set; }
        string[] clubTournaments { get; set; }
        string clubColorCode { get; set; }
        int clubTotalPlayers { get; set; }
    }

    interface National_team_with_EH
    {
        string nationalName { get; set; }
        string nationalCountry { get; set; }
        string nationalColorCode { get; set; }
        string[] nationalTournaments { get; set; }
        int nationalTotalPlayers { get; set; }
    }

    internal class Footballer_with_exception_handling : Club_with_struct, National_team_with_struct
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

        public Footballer_with_exception_handling(string clubName, string clubCountry, string[] clubTournaments, string clubColorCode, int clubTotalPlayers, string nationalName, string nationalCountry, string nationalColorCode, string[] nationalTournaments, int nationalTotalPlayers)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(clubName))
                    throw new ArgumentException("Club name cannot be empty");

                if (string.IsNullOrWhiteSpace(clubCountry))
                    throw new ArgumentException("Club country cannot be empty");

                if (clubTournaments == null)
                    throw new ArgumentNullException("Club tournaments cannot be null");

                if (clubTotalPlayers <= 0)
                    throw new ArgumentOutOfRangeException("Club total players must be greater than zero");

                if (string.IsNullOrWhiteSpace(nationalName))
                    throw new ArgumentException("National team name cannot be empty");

                if (string.IsNullOrWhiteSpace(nationalCountry))
                    throw new ArgumentException("National country cannot be empty");

                if (nationalTournaments == null)
                    throw new ArgumentNullException("National tournaments cannot be null");

                if (nationalTotalPlayers <= 0)
                    throw new ArgumentOutOfRangeException("National total players must be greater than zero");

                // Assign values if everything is valid
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
            catch (Exception ex)
            {
                Console.WriteLine("Error while creating Footballer object:");
                Console.WriteLine(ex.Message);
                throw; // rethrow so caller knows object creation failed
            }
        }

        public void DispData()
        {
            try
            {
                Console.WriteLine("Club Details");
                Console.WriteLine("------------");
                Console.WriteLine("Club: " + clubName);
                Console.WriteLine("Country: " + clubCountry);
                Console.WriteLine("Total Players: " + clubTotalPlayers);

                Console.WriteLine("\nNational Team Details");
                Console.WriteLine("---------------------");
                Console.WriteLine("Team: " + nationalName);
                Console.WriteLine("Country: " + nationalCountry);
                Console.WriteLine("Total Players: " + nationalTotalPlayers);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while displaying data:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

namespace FootballerProj
{
    internal class Program
    {
        static List<FootballerCrud> players = new List<FootballerCrud>();
        static int nextId = 1;

        static void Create()
        {
            Console.Write("Enter Player Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Club Name: ");
            string club = Console.ReadLine();
            Console.Write("Enter National Team: ");
            string national = Console.ReadLine();

            players.Add(new FootballerCrud(nextId++, name, club, national));
            Console.WriteLine("Player added successfully!");
        }

        // READ
        static void Read()
        {
            Console.WriteLine("\n--- Player List ---");
            if (players.Count == 0) Console.WriteLine("No players found.");
            foreach (var p in players) p.DispData();
        }

        // UPDATE
        static void Update()
        {
            Console.Write("Enter Player ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var player = players.FirstOrDefault(p => p.Id == id);
                if (player != null)
                {
                    Console.Write("New Name: ");
                    player.Name = Console.ReadLine();
                    Console.Write("New Club Name: ");
                    player.clubName = Console.ReadLine();
                    Console.Write("New National Team: ");
                    player.nationalName = Console.ReadLine();
                    Console.WriteLine("Update complete!");
                }
                else Console.WriteLine("Player not found.");
            }
        }

        // DELETE
        static void Delete()
        {
            Console.Write("Enter Player ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var player = players.FirstOrDefault(p => p.Id == id);
                if (player != null)
                {
                    players.Remove(player);
                    Console.WriteLine("Player deleted.");
                }
                else Console.WriteLine("Player not found.");
            }
        }
        static void Main(string[] args)
        {
            //Club realMadrid = new Club("Real Madrid", "Spain", "Club", "White-Golden", 100, new string[] {"La liga", "Spanish Cup", "UCL"}, "Bernabu");

            //NationalTeam portugal = new NationalTeam("Portugal", "Portugal", "National", "Red", 100, new string[] {"World Cup", "UEFA Nation s league"}, "UEFA");

            //Player ronaldo = new Player("Cristiano Ronaldo", realMadrid, portugal);

            //Console.WriteLine(ronaldo.PlayerName + " plays for " + ronaldo.MyClub.Name + " and his national team is " + ronaldo.MyNationalTeam.Name);


            /*
            string[] clubTournaments = { "Premier League", "Champions League" };
            string[] nationalTournaments = { "World Cup", "Copa America" };

            Footballer_with_two_interface player = new Footballer_with_two_interface(
                "Manchester City",    
                "UK",                 
                clubTournaments,      
                "Sky Blue",           
                25,                   
                "Argentina",          
                "Argentina",          
                "Light Blue/White",   
                nationalTournaments,  
                23                    
            );

            player.DispData();

            Console.WriteLine($"The player's national color is: {player.nationalColorCode}");
            */

            /*
            string[] clubTournaments = { "Premier League", "Champions League" };
            string[] nationalTournaments = { "World Cup", "Copa America" };

            Footballer_with_struct_and_enum player = new Footballer_with_struct_and_enum(
                ClubEnum.Manchester_City.ToString(),
                CountryEnum.England.ToString(),
                clubTournaments,
                ColorCodeEnum.Sky_Blue.ToString(),
                25,
                CountryEnum.Argentina.ToString(),
                CountryEnum.Argentina.ToString(),
                ColorCodeEnum.Light_Blue_White.ToString(),
                nationalTournaments,
                23
            );

            player.DispData();

            Console.WriteLine($"The player's national color is: {player.nationalColorCode}");
            */

            /*
            string[] clubTournaments = { "Premier League", "Champions League" };
            string[] nationalTournaments = { "World Cup", "Copa America" };

            Footballer_with_collections_and_lambda player1 = new Footballer_with_collections_and_lambda(
                "Manchester City",
                "UK",
                clubTournaments,
                "Sky Blue",
                25,
                "Argentina",
                "Argentina",
                "Light Blue/White",
                nationalTournaments,
                23
            );

            string[] clubTournaments2 = { "La Liga", "Champions League" };
            string[] nationalTournaments2 = { "World Cup", "Euro Cup" };

            Footballer_with_collections_and_lambda player2 = new Footballer_with_collections_and_lambda(
                "Real Madrid",
                "Spain",
                clubTournaments2,
                "White",
                28,
                "France",
                "France",
                "Blue",
                nationalTournaments2,
                10
            );

            string[] clubTournaments3 = { "Serie A", "Champions League", "Coppa Italia" };
            string[] nationalTournaments3 = { "World Cup", "Euro Cup", "Nations League" };

            Footballer_with_collections_and_lambda player3 = new Footballer_with_collections_and_lambda(
                "AC Milan",
                "Italy",
                clubTournaments3,
                "Red/Black",
                31,
                "Italy",
                "Italy",
                "Blue",
                nationalTournaments3,
                8
            );


            string[] clubTournaments4 = { "Bundesliga", "Champions League", "DFB Pokal" };
            string[] nationalTournaments4 = { "World Cup", "Euro Cup" };

            Footballer_with_collections_and_lambda player4 = new Footballer_with_collections_and_lambda(
                "Bayern Munich",
                "Germany",
                clubTournaments4,
                "Red",
                26,
                "Germany",
                "Germany",
                "White",
                nationalTournaments4,
                9
            );

            //player1.DispData();
            //player2.DispData();
            //player3.DispData();
            //player4.DispData();

            List<Footballer_with_collections_and_lambda> listOfPlayers = new List<Footballer_with_collections_and_lambda>()
            {
                player1, player2, player3, player4
            };
            */

            /*
            foreach(var player in listOfPlayers)
            {
                player.DispData();
            }
            */

            /*
            var clubNames = listOfPlayers.Select(x => x.clubName);

            foreach (var clubName in clubNames) Console.WriteLine(clubName);
            */

            /*
            try
            {
                Footballer_with_exception_handling f = new Footballer_with_exception_handling(
                    "Real Madrid",
                    "Spain",
                    new string[] { "La Liga", "UCL" },
                    "White",
                    25,
                    "Spain National Team",
                    "Spain",
                    "Red",
                    new string[] { "World Cup", "Euro Cup" },
                    23
                );

                f.DispData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Application Error:");
                Console.WriteLine(ex.Message);
            }
            */

            /*
            Footballer_with_sealed_extension f = new Footballer_with_sealed_extension(
                "Barcelona",
                "Spain",
                new string[] { "La Liga", "Champions League" },
                "Red Purple",
                25,
                "Spain",
                "Spain",
                "Red Dark Blue",
                new string[] { "World Cup", "Euro Cup" },
                26
            );

            // Calling extension method like a normal instance method
            f.DisplayFullInfo();
            */

            while (true)
            {
                Console.WriteLine("\n--- FOOTBALLER MANAGEMENT (CRUD) ---");
                Console.WriteLine("1. Create Player");
                Console.WriteLine("2. Read All Players");
                Console.WriteLine("3. Update Player");
                Console.WriteLine("4. Delete Player");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1": Create(); break;
                    case "2": Read(); break;
                    case "3": Update(); break;
                    case "4": Delete(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

    }
}


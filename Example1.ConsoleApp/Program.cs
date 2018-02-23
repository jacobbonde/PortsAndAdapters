using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Example1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! I'm your drinking advisor!");

			while (true)
			{
				var input = Console.ReadKey().KeyChar;
				Console.WriteLine();

				switch (input)
				{
					case 'b':
						Console.WriteLine("You asked: 'Should I have a beer now?'");
						BeerNow();
						break;
					case 's':
						Console.WriteLine("You asked: 'Should I have a soda now?'");
						break;					
					default:
						Console.WriteLine("Sorry, what?");
						break;
				}
			}
        }

		private static void BeerNow()
		{
			var imbibements = new List<Imbibement>();

			using (var connection = new MySqlConnection("SERVER=localhost; DATABASE=hexa; UID=root; PASSWORD=bigsecret;"))
			{
				connection.Open();
				var command = new MySqlCommand("select * from drinks", connection);
				var reader = command.ExecuteReader();
				
				while (reader.Read())
				{
					imbibements.Add(new Imbibement
					{
						Drinker = reader.GetString("drinker"),
						Type = reader.GetString("type"),
						Time = reader.GetDateTime("time")
					});
				}								
			}

			if (imbibements.Count(i => i.Type == "Beer" && (DateTime.Now - i.Time) < TimeSpan.FromHours(4)) > 3)
			{
				Console.WriteLine("No, you've had enough.");
			}
			else
			{
				Console.WriteLine("Sure, have a beer!");

				using (var connection = new MySqlConnection("SERVER=localhost; DATABASE=hexa; UID=root; PASSWORD=bigsecret;"))
				{
					connection.Open();
					var command = new MySqlCommand("insert into drinks values ('Jacob', 'Beer', now())", connection);
					command.ExecuteNonQuery();					
				}
			}
		}
	}

	internal class Imbibement
	{
		public string Drinker { get; internal set; }
		public string Type { get; internal set; }
		public DateTime Time { get; internal set; }
	}
}

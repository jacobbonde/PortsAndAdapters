using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Example2.DataAccess
{
    public class ImbibementRepository
    {
		public IEnumerable<Imbibement> Imbibements()
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

			return imbibements;
		}

		public void Add(Imbibement imbibement)
		{
			using (var connection = new MySqlConnection("SERVER=localhost; DATABASE=hexa; UID=root; PASSWORD=bigsecret;"))
			{
				connection.Open();
				var command = new MySqlCommand($"insert into drinks values (@drinker, @type, @time)", connection);
				command.Parameters.AddWithValue("@drinker", imbibement.Drinker);
				command.Parameters.AddWithValue("@type", imbibement.Type);
				command.Parameters.AddWithValue("@time", imbibement.Time);
				command.ExecuteNonQuery();
			}
		}
	}
}

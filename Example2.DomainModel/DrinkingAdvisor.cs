using Example2.DataAccess;
using System;
using System.Linq;

namespace Example2.DomainModel
{
	public class DrinkingAdvisor
	{
		public bool BeerNow()
		{
			var imbibementRepo = new ImbibementRepository();
			var imbibements = imbibementRepo.Imbibements();

			if (imbibements.Count(i => i.Type == "Beer" && (DateTime.Now - i.Time) < TimeSpan.FromHours(4)) > 3)
			{
				return false;				
			}
			else
			{
				imbibementRepo.Add(new Imbibement
				{
					Drinker = "Jacob",
					Type = "Beer",
					Time = DateTime.Now

				});

				return true;				
			}
		}
	}
}

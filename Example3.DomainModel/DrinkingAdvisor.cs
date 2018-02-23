using System;
using System.Linq;

namespace Example3.DomainModel
{
	public class DrinkingAdvisor
	{
		private readonly IImbibementRepository imbibementRepository;

		public DrinkingAdvisor(IImbibementRepository imbibementRepository)
		{
			this.imbibementRepository = imbibementRepository;
		}

		public bool BeerNow()
		{			
			var imbibements = imbibementRepository.Imbibements();

			if (imbibements.Count(i => i.Type == "Beer" && (DateTime.Now - i.Time) < TimeSpan.FromHours(4)) > 3)
			{
				return false;				
			}
			else
			{
				imbibementRepository.Add(new Imbibement
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

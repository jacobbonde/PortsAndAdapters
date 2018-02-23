using Example3.DomainModel;
using Xunit;
using System.Collections.Generic;

namespace Example3.Tests
{
    public class DrinkingAdvisorTest
    {
		[Fact]
        public void AdvisorSaysYesToFirstBeer()
        {
			var advisor = new DrinkingAdvisor(new InMemoryImbibementRepository());

			Assert.True(advisor.BeerNow());
        }

		[Fact]
		public void AdvisorSaysYesToSecondBeer()
		{
			var advisor = new DrinkingAdvisor(new InMemoryImbibementRepository());

			advisor.BeerNow();
			Assert.True(advisor.BeerNow());
		}

		[Fact]
		public void AdvisorSaysYesToThirdBeer()
		{
			var advisor = new DrinkingAdvisor(new InMemoryImbibementRepository());

			advisor.BeerNow();
			advisor.BeerNow();
			Assert.True(advisor.BeerNow());
		}

		[Fact]
		public void AdvisorSaysYesToFourthBeer()
		{
			var advisor = new DrinkingAdvisor(new InMemoryImbibementRepository());

			advisor.BeerNow();
			advisor.BeerNow();
			advisor.BeerNow();		
			Assert.True(advisor.BeerNow());
		}

		[Fact]
		public void AdvisorSaysNoToFifthBeer()
		{
			var advisor = new DrinkingAdvisor(new InMemoryImbibementRepository());

			advisor.BeerNow();
			advisor.BeerNow();
			advisor.BeerNow();
			advisor.BeerNow();
			Assert.False(advisor.BeerNow());
		}
	}

	internal class InMemoryImbibementRepository : IImbibementRepository
	{
		private List<Imbibement> imbibements = new List<Imbibement>();

		public void Add(Imbibement imbibement)
		{
			this.imbibements.Add(imbibement);
		}

		public IEnumerable<Imbibement> Imbibements()
		{
			return imbibements;
		}
	}
}

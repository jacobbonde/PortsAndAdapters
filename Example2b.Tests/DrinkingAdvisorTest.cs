using Example2b.DataAccess;
using Example2b.DomainModel;
using System.Collections.Generic;
using Xunit;

namespace Example2b.Tests
{
  public class DrinkingAdvisorTest
  {
    [Fact]
    public void AdvisorSaysYesToFirstBeer()
    {
      var advisor = NewAdvisor();

      Assert.True(advisor.BeerNow());
    }    

    [Fact]
    public void AdvisorSaysYesToSecondBeer()
    {
      var advisor = NewAdvisor();

      advisor.BeerNow();
      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysYesToThirdBeer()
    {
      var advisor = NewAdvisor();

      advisor.BeerNow();
      advisor.BeerNow();
      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysYesToFourthBeer()
    {
      var advisor = NewAdvisor();

      advisor.BeerNow();
      advisor.BeerNow();
      advisor.BeerNow();
      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysNoToFifthBeer()
    {
      var advisor = NewAdvisor();

      advisor.BeerNow();
      advisor.BeerNow();
      advisor.BeerNow();
      advisor.BeerNow();
      Assert.False(advisor.BeerNow());
    }

    private static DrinkingAdvisor NewAdvisor()
    {
      return new DrinkingAdvisor(
				new InMemoryImbibementRepository(), 
				new MockEventPublisher());
    }
  }

  internal class InMemoryImbibementRepository : IImbibementRepository
  {
    private List<Imbibement> imbibements = new List<Imbibement>();

    public void Add(Imbibement imbibement)
    {
      imbibements.Add(imbibement);
    }

    public IEnumerable<Imbibement> Imbibements()
    {
      return imbibements;
    }
  }

  internal class MockEventPublisher : IEventPublisher
  {
    public void Publish(BeerOrdered beerOrdered)
    {
    }
  }
}

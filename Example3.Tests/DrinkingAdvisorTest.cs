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
      DrinkingAdvisor advisor = NewDrinkingAdvisor();

      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysYesToSecondBeer()
    {
      var advisor = NewDrinkingAdvisor();

      advisor.BeerNow();
      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysYesToThirdBeer()
    {
      var advisor = NewDrinkingAdvisor();

      advisor.BeerNow();
      advisor.BeerNow();
      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysYesToFourthBeer()
    {
      var advisor = NewDrinkingAdvisor();

      advisor.BeerNow();
      advisor.BeerNow();
      advisor.BeerNow();
      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysNoToFifthBeer()
    {
      var advisor = NewDrinkingAdvisor();

      advisor.BeerNow();
      advisor.BeerNow();
      advisor.BeerNow();
      advisor.BeerNow();
      Assert.False(advisor.BeerNow());
    }
    private static DrinkingAdvisor NewDrinkingAdvisor()
    {
      return new DrinkingAdvisor(new InMemoryImbibementRepository(), new MockEventPublisher());
    }
  }

  internal class MockEventPublisher : IEventPublisher
  {
    public void Publish(BeerOrdered eventObject)
    {
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
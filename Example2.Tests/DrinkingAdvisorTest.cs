using Example2.DomainModel;
using Xunit;

namespace Example2.Tests
{
  public class DrinkingAdvisorTest
  {
    [Fact]
    public void AdvisorSaysYesToFirstBeer()
    {
      var advisor = new DrinkingAdvisor();

      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysYesToSecondBeer()
    {
      var advisor = new DrinkingAdvisor();

      advisor.BeerNow();
      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysYesToThirdBeer()
    {
      var advisor = new DrinkingAdvisor();

      advisor.BeerNow();
      advisor.BeerNow();
      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysYesToFourthBeer()
    {
      var advisor = new DrinkingAdvisor();

      advisor.BeerNow();
      advisor.BeerNow();
      advisor.BeerNow();
      Assert.True(advisor.BeerNow());
    }

    [Fact]
    public void AdvisorSaysNoToFifthBeer()
    {
      var advisor = new DrinkingAdvisor();

      advisor.BeerNow();
      advisor.BeerNow();
      advisor.BeerNow();
      advisor.BeerNow();
      Assert.False(advisor.BeerNow());
    }
  }
}

using Example2b.DataAccess;
using System;
using System.Linq;

namespace Example2b.DomainModel
{
  public class DrinkingAdvisor
  {
    private readonly IImbibementRepository imbibementRepository;
    private readonly IEventPublisher eventPublisher;

    public DrinkingAdvisor(
			IImbibementRepository imbibementRepository,
			IEventPublisher eventPublisher)
    {
      this.imbibementRepository = imbibementRepository;
      this.eventPublisher = eventPublisher;
    }
    public bool BeerNow()
    {
      var imbibements = imbibementRepository.Imbibements();

      if (imbibements.Count(i =>
            i.Type == "Beer" &&
            (DateTime.Now - i.Time) < TimeSpan.FromHours(4)) > 3)
      {
        return false;
      }

      var imbibement = new Imbibement
      {
        Drinker = "Jacob",
        Type = "Beer",
        Time = DateTime.Now

      };

      imbibementRepository.Add(imbibement);

      eventPublisher.Publish(
                new BeerOrdered
                {
                  Drinker = imbibement.Drinker,
                  Time = imbibement.Time
                });

      return true;
    }
  }
}
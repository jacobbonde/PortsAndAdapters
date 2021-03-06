﻿using System;
using System.Linq;

namespace Example3.DomainModel
{
  public class DrinkingAdvisor
  {
    private readonly IEventPublisher eventPublisher;
    private readonly IImbibementRepository imbibementRepository;

    public DrinkingAdvisor(
            IImbibementRepository imbibementRepository,
            IEventPublisher eventPublisher)
    {
      this.eventPublisher = eventPublisher;
      this.imbibementRepository = imbibementRepository;
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
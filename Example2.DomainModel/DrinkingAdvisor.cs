using Example2.DataAccess;
using System;
using System.Linq;
using System.Net.Mail;

namespace Example2.DomainModel
{
  public class DrinkingAdvisor
  {
    private readonly ImbibementRepository imbibementRepository;
    private readonly SmtpClient smtp = new SmtpClient();

    public DrinkingAdvisor()
    {
      imbibementRepository = new ImbibementRepository();
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

      smtp.Send("app@drinkingadvisor.com",
                "jacobsWife@home.dk",
                "Jacob had a beer",
                "Yeah, he's probably at the Friday Bar");

      return true;
    }
  }
}
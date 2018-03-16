using Example3.DomainModel;
using System;

namespace Example3.Integrations
{
  public class MailEventPublisher : IEventPublisher
  {
    public void Publish(BeerOrdered beerOrdered)
    {
			// Send an email to subscribers
      throw new NotImplementedException();
    }
  }
}

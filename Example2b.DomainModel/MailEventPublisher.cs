using System;

namespace Example2b.DomainModel
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

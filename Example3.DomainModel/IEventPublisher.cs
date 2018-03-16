namespace Example3.DomainModel
{
  public interface IEventPublisher
  {
    void Publish(BeerOrdered beerOrdered);
  }
}
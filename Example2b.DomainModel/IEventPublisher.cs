namespace Example2b.DomainModel
{
  public interface IEventPublisher
  {
    void Publish(BeerOrdered beerOrdered);
  }
}
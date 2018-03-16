using Example2b.DataAccess;
using Example2b.DomainModel;
using System;

namespace Example2b.ConsoleApp
{
  class Program
  {
    static DrinkingAdvisor advisor = new DrinkingAdvisor(
			new ImbibementRepository(), 
			new MailEventPublisher());

    static void Main(string[] args)
    {
      Console.WriteLine("Hi! I'm your drinking advisor!");

      while (true)
      {
        var input = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (input)
        {
          case 'b':
            BeerNow();
            break;          
          default:
            Console.WriteLine("Sorry, what?");
            break;
        }
      }
    }

    private static void BeerNow()
    {
      Console.WriteLine("You asked: 'Can I have a beer, please?'");

      if (advisor.BeerNow())
      {
        Console.WriteLine("Sure, have a beer!");
      }
      else
      {
        Console.WriteLine("No, you've had enough.");
      }
    }
  }
}

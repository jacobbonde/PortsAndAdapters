using Example3.DataAccess;
using Example3.DomainModel;
using Example3.Integrations;
using System;

namespace Example3.ConsoleApp
{
	class Program
	{
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
			Console.WriteLine("You asked: 'Should I have a beer now?'");

			var advisor = new DrinkingAdvisor(
							new MySqlImbibementRepository(), 
							new MailEventPublisher());

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

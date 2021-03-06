﻿using Example2.DomainModel;
using System;

namespace Example2.ConsoleApp
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
			Console.WriteLine("You asked: 'Can I have a beer, please?'");

			var advisor = new DrinkingAdvisor();

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

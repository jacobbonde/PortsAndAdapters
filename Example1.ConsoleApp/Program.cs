using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace Example1.ConsoleApp
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
            Console.WriteLine("Q: 'Can I have a beer, please?'");
            BeerPlease();
            break;
          default:
            Console.WriteLine("Sorry, what?");
            break;
        }
      }
    }

    private static void BeerPlease()
    {
      var imbibements = new List<Imbibement>();

      using (var connection = GetConnection())
      {
        connection.Open();
        var command = new MySqlCommand(
                    "select * from drinks",
                    connection);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
          imbibements.Add(new Imbibement
          {
            Drinker = reader.GetString("drinker"),
            Type = reader.GetString("type"),
            Time = reader.GetDateTime("time")
          });
        }
      }

      if (imbibements.Count(i =>
        i.Type == "Beer"
        && (DateTime.Now - i.Time) < TimeSpan.FromHours(4)) > 3)
      {
        Console.WriteLine("No, you've had enough.");
      }
      else
      {
        Console.WriteLine("Sure, have a beer!");

        using (var connection = GetConnection())
        {
          connection.Open();
          var command = new MySqlCommand(
            "insert into drinks values ('Jacob', 'Beer', now())",
            connection);
          command.ExecuteNonQuery();
        }

        var smtp = new SmtpClient();
        smtp.Send("app@drinkingadvisor.com", 
									"jacobsWife@home.dk", 
									"Jacob had a beer", 
									"Yeah, he's probably at the Friday Bar");
      }
    }

    private static MySqlConnection GetConnection()
    {
      return new MySqlConnection(
              "SERVER=localhost;" +
              "DATABASE=hexa;" +
              "UID=root;" +
              "PASSWORD=bigsecret;");
    }
  }

  internal class Imbibement
  {
    public string Drinker { get; internal set; }
    public string Type { get; internal set; }
    public DateTime Time { get; internal set; }
  }
}

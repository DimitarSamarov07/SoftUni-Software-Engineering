using System;
using System.Collections.Generic;
using System.Linq;

namespace Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();
            var gamesAndPrice = new Dictionary<string, double>();
            var gamesAndDLC = new Dictionary<string, string>();
            List<string> withDLC = new List<string>();
            List<string> withoutDLC = new List<string>();
            List<string> toRemove = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {

                if (input[i].Contains("-"))
                {
                    string[] commands = input[i].Split("-").ToArray();
                    string game = commands[0];
                    double price = double.Parse(commands[1]);
                    withoutDLC.Add(game);
                    gamesAndPrice.Add(game, price);

                }

                else if (input[i].Contains(":"))
                {
                    string[] commands = input[i].Split(":").ToArray();
                    string game = commands[0];
                    string DLC = commands[1];
                   

                    if (gamesAndPrice.ContainsKey(game))
                    {
                        gamesAndDLC.Add(game, DLC);
                        gamesAndPrice[game] = gamesAndPrice[game] + (gamesAndPrice[game] * 0.2);
                        withDLC.Add(game);
                        withoutDLC.Remove(game);
                    }
                }

            }
            for (int i = 0; i < withoutDLC.Count; i++)
            {
                string current = withoutDLC[i];
                gamesAndPrice[current] = gamesAndPrice[current] - (gamesAndPrice[current] * 0.2);
            }

            for (int i = 0; i < withDLC.Count; i++)
            {
                string current = withDLC[i];
                gamesAndPrice[current] = gamesAndPrice[current] - (gamesAndPrice[current] * 0.5);
            }

            foreach (var kvp in gamesAndDLC.OrderBy(x => x.Value))
            {
                double currentGamePrice = gamesAndPrice[kvp.Key] ;
                Console.WriteLine($"{kvp.Key} - {kvp.Value} - {currentGamePrice:f2}");
            }


            for (int i = 0; i < withDLC.Count; i++)
            {

                gamesAndPrice.Remove(withDLC[i]);
            }
            foreach (var kvp in gamesAndPrice.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value:f2}");
            }

        }
    }
}

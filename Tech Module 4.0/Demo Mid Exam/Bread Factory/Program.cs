using System;
using System.Linq;

namespace P09PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] events = Console.ReadLine().Split('|').ToArray();
            int initialEnergy = 100;
            int initialCoins = 100;

            for (int i = 0; i < events.Length; i++)
            {
                string[] currentEvent = events[i].Split("-").ToArray();
                string command = currentEvent[0];
                int number = int.Parse(currentEvent[1]);

                if (command == "rest")
                {
                    int currentEnergy = initialEnergy;
                    initialEnergy += number;
                    if (initialEnergy > 100)
                    {
                        initialEnergy = 100;
                        Console.WriteLine($"You gained {100 - currentEnergy} energy.");
                        Console.WriteLine($"Current energy: {currentEnergy}.");
                        
                    }
                    else if (initialEnergy==100)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"You gained {number} energy.");
                        Console.WriteLine($"Current energy: {initialEnergy}.");
                    }

                }
                else if (command == "order")
                {

                    initialEnergy -= 30;
                    if (initialEnergy < 0)
                    {
                        Console.WriteLine("You had to rest!");
                        initialEnergy += 80;
                    }

                    else
                    {
                        Console.WriteLine($"You earned {number} coins.");
                        initialCoins += number;
                    }



                }
                else
                {

                    if (initialCoins > number)
                    {
                        Console.WriteLine($"You bought {command}.");
                        initialCoins -= number;
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {command}.");
                        return;
                    }
                }
            }
            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {initialCoins}");
            Console.WriteLine($"Energy: {initialEnergy}");

        }
    }
}
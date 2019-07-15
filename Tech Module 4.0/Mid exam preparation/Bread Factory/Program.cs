using System;
using System.Collections.Generic;
using System.Linq;

namespace Bread_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Event = Console.ReadLine().Split("|").ToList();
            int initialEnergy = 100;
            int initialCoins = 100;
            bool YEEEE = true;
            for (int i = 0; i < Event.Count; i++)
            {
                List<string> currentEvent = Event[i].Split("-").ToList();
                string command = currentEvent[0];
                int number = int.Parse(currentEvent[1]);
                string ingredient = command;

                if (command == "rest")
                {
                    if ((initialEnergy + number) > 100)
                    {


                        Console.WriteLine($"You gained {100 - initialEnergy} energy.");
                        Console.WriteLine($"Current energy: {initialEnergy}.");
                        initialEnergy = 100;
                    }
                    else if ((initialEnergy + number) <= 100)
                    {
                        initialEnergy += number;
                        Console.WriteLine($"You gained {number} energy.");
                        Console.WriteLine($"Current energy: {initialEnergy}.");
                    }
                }

                else if (command == "order")
                {

                    if (initialEnergy >= 30)
                    {
                        initialEnergy -= 30;
                        initialCoins += number;
                        Console.WriteLine($"You earned {number} coins.");
                    }
                    else
                    {

                        initialEnergy += 50;
                        Console.WriteLine("You had to rest!");
                    }
                }
                else
                {
                    initialCoins -= number;
                    if (initialCoins <= 0)
                    {
                        Console.WriteLine($"Closed! Cannot afford {ingredient}.");
                        YEEEE = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You bought {ingredient}.");
                    }

                }
            }
            if (YEEEE)
            {
                Console.WriteLine("Day completed!");
                Console.WriteLine($"Coins: {initialCoins}");
                Console.WriteLine($"Energy: {initialEnergy}");
            }



        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = 100;
            int initialCoins = 0;
            
            List<string> input = Console.ReadLine().Split("|").ToList();
            for (int index = 0; index < input.Count; index++)
            {
                string currentString = input[index];
                List<string> current = currentString.Split(" ").ToList();
                string Event = current[0];
                int number = int.Parse(current[1]);
                string monster = Event;

                if (Event=="potion")
                {
                    if ((initialHealth+number)>100)
                    {
                        Console.WriteLine($"You healed for {100-initialHealth} hp.");
                        initialHealth = 100;
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }
                    else if ((initialHealth+number)<=100)
                    {
                        initialHealth += number;
                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }
                }

                else if (Event=="chest")
                {
                    initialCoins += number;
                    Console.WriteLine($"You found {number} coins.");
                }

                else
                {
                    initialHealth -= number;
                    if (initialHealth<=0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {index+1}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                }
                
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {initialCoins}");
            Console.WriteLine($"Health: {initialHealth}");
        }
    }
}

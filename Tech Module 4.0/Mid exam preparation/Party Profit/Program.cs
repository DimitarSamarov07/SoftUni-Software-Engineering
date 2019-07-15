﻿using System;

namespace Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int coins = 0;

            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                if (currentDay % 15 == 0)
                {
                    partySize += 5;

                }
                if (currentDay % 10 == 0)
                {
                    partySize -= 2;
                }
                coins += 50;
                coins -= partySize * 2;

                
               
                if (currentDay % 3 == 0)
                {
                    coins -= partySize * 3;
                }
                if (currentDay % 5 == 0)
                {
                    coins += 20 * partySize;
                    if (currentDay % 3 == 0)
                    {
                        coins -= partySize * 2;
                    }
                }
               
               
            }
            int result = coins / partySize;
            Console.WriteLine($"{partySize} companions received {result} coins each.");
        }
    }
}

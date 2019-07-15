using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();

            if (command=="even")
            {
                int start = line[0];
                int end = line[1];

                for (int i = start; i <= end; i++)
                {
                    if (i%2==0)
                    {
                        Console.Write(i+" ");
                    }
                }
            }

            else if (command == "odd")
            {
                int start = line[0];
                int end = line[1];

                for (int i = start; i <= end; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write(i+" ");
                    }
                }
            }
        }
    }
}

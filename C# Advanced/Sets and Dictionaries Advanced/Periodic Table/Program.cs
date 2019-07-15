using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < line.Length; j++)
                {
                    set.Add(line[j]);
                }

            }

            foreach (var item in set.OrderBy(x=>x))
            {
                Console.Write(item+" ");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string line = Console.ReadLine();
                set.Add(line);
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}

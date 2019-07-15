using System;
using System.Linq;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int criteria = int.Parse(Console.ReadLine());
            string[] line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Predicate<string> predicate = x => x.Length <= criteria;

            for (int i = 0; i < line.Length; i++)
            {
                if (predicate(line[i]))
                {
                    Console.WriteLine(line[i]);
                }
            }
        }
    }
}

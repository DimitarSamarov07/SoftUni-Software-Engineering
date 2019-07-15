using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            Family fam = new Family();
            for (int i = 0; i < countOfLines; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = line[0];
                int age = int.Parse(line[1]);
                Person current = new Person(name,age);
                
                fam.AddMember(current);
            }

            Dictionary<string, int> results = fam.GetUnder30();
            foreach (var result in results.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{result.Key} - {result.Value}");
            }


        }
    }
}

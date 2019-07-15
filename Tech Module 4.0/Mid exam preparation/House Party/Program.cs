using System;
using System.Collections.Generic;
using System.Linq;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> partyList = new List<string>();
            int index = 0;
            for (int i = 0; i <= partyList.Count; i++)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                string name = input[0];
                if (input.Contains("not"))
                {
                    if (partyList.Contains(name))
                    {
                        index = partyList.IndexOf(name);
                        partyList.RemoveAt(index);

                    }
                    if (!partyList.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                if (!input.Contains("not"))
                {
                    partyList.Add(name);
                }

            }

            foreach (var item in partyList)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}

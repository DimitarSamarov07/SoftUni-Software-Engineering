using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string wordsToDisplay = Console.ReadLine();
            string command = Console.ReadLine();
            var wordsAndDefinitions = new SortedDictionary<string, List<string>>();
            List<string> input = line.Split(" | ").ToList();

            for (int i = 0; i < input.Count; i++)
            {
                List<string> current = input[i].Split(":").ToList();
                string word = current[0];
                string definition = current[1];
                if (wordsAndDefinitions.ContainsKey(word))
                {
                    wordsAndDefinitions[word].Add(definition);
                }

                else
                {
                    wordsAndDefinitions.Add(word,null);
                    wordsAndDefinitions[word] = new List<string>();
                    wordsAndDefinitions[word].Add(definition);
                }
                
            }

            if (command=="List")
            {
                foreach (var kvp in wordsAndDefinitions.OrderBy(x=>x.Key))
                {
                    Console.Write($"{kvp.Key} ");
                }
            }

            if (command=="End")
            {
                
                foreach (var kvp in wordsAndDefinitions.OrderBy(x=>x.Key).ThenBy(x=>x.Value.Count))
                {
                    
                    Console.WriteLine($"{kvp.Key}:");
                    for (int i = 0; i < kvp.Value.Count; i++)
                    {
                        Console.WriteLine($"-{kvp.Value[i]}")
                    }
                }
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Dictionary<string,Dictionary<string,int>> dict = new Dictionary<string, Dictionary<string, int>>();
            string input = String.Empty;
            for (int i = 0; i < numberOfLines; i++)
            {
                input = Console.ReadLine();
                string[] colorSplitter = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = colorSplitter[0];

                string[] items = colorSplitter[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < items.Length; j++)
                {
                    if (!dict.ContainsKey(color))
                    {
                        dict.Add(color,new Dictionary<string, int>());
                        dict[color].Add(items[j],0);
                    }

                    if (!dict[color].ContainsKey(items[j]))
                    {
                        dict[color].Add(items[j], 1);
                    }
                    else
                    {
                        dict[color][items[j]]++;
                    }
                }
            }

            string[] whatAreYouLookingFor = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var item1 in item.Value)
                {
                    if (item.Key==whatAreYouLookingFor[0])
                    {
                        if (item1.Key == whatAreYouLookingFor[1])
                        {
                            Console.WriteLine($"* {item1.Key} - {item1.Value} (found!)");
                        }

                        else
                        {
                            Console.WriteLine($"* {item1.Key} - {item1.Value}");
                        }
                    }
                    

                    else
                    {
                        Console.WriteLine($"* {item1.Key} - {item1.Value}");
                    }
                }
            }
        }
    }
}

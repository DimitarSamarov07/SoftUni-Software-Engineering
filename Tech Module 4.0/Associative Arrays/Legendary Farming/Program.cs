using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> quantityMaterial = new SortedDictionary<string, int>();
            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();
            quantityMaterial.Add("fragments", 0);
            quantityMaterial.Add("motes", 0);
            quantityMaterial.Add("shards", 0);
            string winner = string.Empty;

            while (true)
            {
                List<string> materials = Console.ReadLine().ToLower().Split(' ').ToList();

                for (int i = 0; i < materials.Count; i += 2)
                {
                    if (materials[i + 1] == "fragments" || materials[i + 1] == "motes"
                        || materials[i + 1] == "shards")
                    {
                        quantityMaterial[materials[i + 1]] += int.Parse(materials[i]);
                    }
                    else if (junk.ContainsKey(materials[i + 1]) == false)
                    {
                        junk.Add(materials[i + 1], int.Parse(materials[i]));
                    }
                    else if (junk.ContainsKey(materials[i + 1]))
                    {
                        junk[materials[i + 1]] += int.Parse(materials[i]);
                    }
                    if (quantityMaterial["fragments"] >= 250 ||
                        quantityMaterial["motes"] >= 250 || quantityMaterial["shards"] >= 250)
                    {
                        break;
                    }
                }
                if (quantityMaterial["fragments"] >= 250)
                {
                    quantityMaterial["fragments"] -= 250;
                    winner = "Valanyr";
                    break;
                }
                else if (quantityMaterial["shards"] >= 250)
                {
                    quantityMaterial["shards"] -= 250;
                    winner = "Shadowmourne";
                    break;
                }
                else if (quantityMaterial["motes"] >= 250)
                {
                    quantityMaterial["motes"] -= 250;
                    winner = "Dragonwrath";
                    break;
                }
            }
            Console.WriteLine($"{winner} obtained!");

            foreach (var noJunk in quantityMaterial.OrderByDescending(v => v.Value))
            {
                Console.WriteLine($"{noJunk.Key}: {noJunk.Value}");
            }
            foreach (var junkies in junk)
            {
                Console.WriteLine($"{junkies.Key}: {junkies.Value}");
            }
        }
    }
}
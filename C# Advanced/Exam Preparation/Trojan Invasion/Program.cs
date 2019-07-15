using System;
using System.Collections.Generic;
using System.Linq;
 
namespace _01TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesOfWarriors = int.Parse(Console.ReadLine());
            List<int> plates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
 
            Stack<int> stackOfWarriors = null;
            bool isDestroyed = false;
           
            for (int wave = 1; wave <= wavesOfWarriors; wave++)
            {
                List<int> powerOfWarriors = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                stackOfWarriors = new Stack<int>(powerOfWarriors);
 
                if (wave % 3 == 0)
                {
                    int extraWave = int.Parse(Console.ReadLine());
                    plates.Add(extraWave);
                }
 
                while (stackOfWarriors.Count > 0 && plates.Count > 0)
                {
                    int currentWarrior = stackOfWarriors.Peek();
 
                    if (currentWarrior > plates[0])
                    {
                        currentWarrior -= plates[0];
                        stackOfWarriors.Pop();
                        stackOfWarriors.Push(currentWarrior);
                        plates.RemoveAt(0);
                    }
                    else if (plates[0] > currentWarrior)
                    {
                        currentWarrior = stackOfWarriors.Pop();
                        plates[0] -= currentWarrior;
                    }
                    else
                    {
                        stackOfWarriors.Pop();
                        plates.RemoveAt(0);
                    }
 
                    if (plates.Count == 0)
                    {
                        isDestroyed = true;
                        break;
                    }
                }
 
                if (isDestroyed)
                {
                    break;
                }
            }
 
            if (plates.Count != 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", stackOfWarriors)}");
            }
        }
    }
}
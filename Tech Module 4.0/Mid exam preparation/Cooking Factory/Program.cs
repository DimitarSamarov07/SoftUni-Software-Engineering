using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal bestSum = decimal.MinValue;
            string bestString = "";
            string command = "";

            while (true)
            {
                List<string> input = new List<string>();
                decimal currentSum = 0;
                string currentString = "";
                command = Console.ReadLine();
                if (command == "Bake It!")
                {
                    break;
                }
                input = command.Split("#").ToList();
                for (int i = 0; i < input.Count; i++)
                {
                    currentSum += int.Parse(input[i]);

                }
                currentString = String.Join(" ", input);
                decimal first = 0;
                decimal second = 0;
                List<string> current = currentString.Split(" ").ToList();
                List<string> best = bestString.Split(" ").ToList();
                first = currentSum / current.Count;
                second = bestSum / best.Count;
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    bestString = string.Empty;
                    bestString = currentString;
                }
                else if (currentSum == bestSum && first == second)
                {
                    if (current.Count < best.Count)
                    {
                        bestSum = currentSum;
                        bestString = string.Empty;
                        bestString = currentString;
                    }
                }
                else if (currentSum == bestSum)
                {
                    if (first > second)
                    {
                        bestSum = currentSum;
                        bestString = string.Empty;
                        bestString = currentString;
                    }


                }


            }
            Console.WriteLine($"Best Batch quality: {bestSum}");
            Console.WriteLine(bestString);
        }
    }
}
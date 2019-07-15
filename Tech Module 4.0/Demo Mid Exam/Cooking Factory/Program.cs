using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> batch = Console.ReadLine()
                .Split('#')
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Bake It!")
            {
                List<int> currentBatch = command.Split('#')
                    .Select(int.Parse)
                    .ToList();

                if (batch.Sum() < currentBatch.Sum())
                {
                    batch = currentBatch;
                }
                if (batch.Sum() == currentBatch.Sum() && batch.Count > currentBatch.Count)
                {
                    batch = currentBatch;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {batch.Sum()}");
            Console.WriteLine(string.Join(" ", batch));
        }
    }
}
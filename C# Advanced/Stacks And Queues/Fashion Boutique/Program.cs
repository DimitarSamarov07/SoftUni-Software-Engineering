using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());
            int currentRackCapacity = 0;
            int rackCount = 1;

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < line.Length; i++)
            {
                if (stack.Sum()+line[i]>capacity)
                {
                    stack.Clear();
                    rackCount += 1;
                    currentRackCapacity = 0;
                    currentRackCapacity += line[i];
                    stack.Push(line[i]);
                }

                else
                {
                    currentRackCapacity += line[i];
                    stack.Push(line[i]);
                }
            }

            Console.WriteLine(rackCount);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> queue = new Queue<int>();
            int[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToEnqueue = commands[0];
            int elementsToDequeue = commands[1];
            int elementToCheck = commands[2];

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queue.Enqueue(line[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (queue.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}

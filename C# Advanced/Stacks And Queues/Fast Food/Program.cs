using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Food
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            List<int> line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int ordersCount = line.Count;
            bool isComplete = false;
            Queue<int> queue = new Queue<int>(line);
            Console.WriteLine(queue.Max());



            while (true)
            {
                if (queue.Count == 0)
                {
                    isComplete = true;
                    break;
                }
                int currentOrder = queue.Peek();
                if (currentOrder <= food)
                {
                    food -= currentOrder;
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (isComplete)
            {
                Console.WriteLine("Orders complete");
            }

            else
            {
                Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
            }




        }
    }
}

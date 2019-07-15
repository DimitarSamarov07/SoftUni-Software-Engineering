using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < times; i++)
            {

                int[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (line.Length == 0)
                {
                    return;
                }
                int command = line[0];
                if (command == 1)
                {
                    int element = line[1];
                    stack.Push(element);
                }

                else if (command == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }

                }
                else if (command == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }

                }

                else if (command == 4)
                {

                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                    
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine(String.Join(", ", stack));
            }

        }
    }
}

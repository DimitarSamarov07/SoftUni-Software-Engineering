using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Basic
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToPush = commands[0];
            int elementsToPop = commands[1];
            int elementToCheck = commands[2];

            for (int i = 0; i < elementsToPush; i++)
            {
                stack.Push(line[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count==0)
            {
                Console.WriteLine("0");
                return;
            }
            if (stack.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(stack.Min());
            }
            
        }
    }
}

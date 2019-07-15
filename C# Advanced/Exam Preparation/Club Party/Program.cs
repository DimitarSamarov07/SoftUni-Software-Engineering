using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Stack<string> stack = new Stack<string>(input);

            while (stack.Count!=0)
            {
                
            }
        }
    }
}

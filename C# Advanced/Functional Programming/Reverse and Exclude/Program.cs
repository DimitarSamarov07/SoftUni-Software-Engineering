using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> forRemoving=new List<int>();

            int divider = int.Parse(Console.ReadLine());
            Predicate<int> willItBeRemoved = n => n % divider == 0;
            line.Reverse();

            for (int i = 0; i < line.Count; i++)
            {
                if (willItBeRemoved(line[i]))
                {
                    forRemoving.Add(line[i]);
                }
            }

            for (int i = 0; i < forRemoving.Count; i++)
            {
                line.Remove(forRemoving[i]);
            }
            foreach (var item in line)
            {
                Console.Write(item+" ");
            }

        }
    }
}

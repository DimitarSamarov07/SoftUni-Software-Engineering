using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Dictionary<int, int> dict = new Dictionary<int, int>(); int input = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                input = int.Parse(Console.ReadLine());
                if (dict.ContainsKey(input))
                {
                    dict[input]++;
                }

                else
                {
                    dict.Add(input, 1);
                }
            }

            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }

        }
    }
}

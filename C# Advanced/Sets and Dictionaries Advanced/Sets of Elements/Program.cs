using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstSetLenght = line[0];
            int secondSetLenght = line[1];
            HashSet<int> set1=new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            int input = 0;
            
            
                for (int i = 0; i < firstSetLenght; i++)
                {
                    input = int.Parse(Console.ReadLine());
                    set1.Add(input);
                }

                for (int i = 0; i < secondSetLenght; i++)
                {
                    input = int.Parse(Console.ReadLine());
                    set2.Add(input);
                }

                foreach (var item in set1)
                {
                    if (set2.Contains(item))
                    {
                        Console.Write(item+" ");
                    }
                }



           
            
        }
    }
}

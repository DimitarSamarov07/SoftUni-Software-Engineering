using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var item in inputArray)
            {
                Print(item);
            }
           
        }

        static void Print(string name)
        {
            Console.WriteLine(name);
        }

    }
}

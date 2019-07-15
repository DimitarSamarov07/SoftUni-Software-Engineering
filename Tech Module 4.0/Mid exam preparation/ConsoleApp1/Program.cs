using System;
using System.Collections.Generic;
using System.Linq;
 
namespace P04._Mixed_up_Lists
{
    class StartUp
    {
        static void Main()
        {
            List<string> firstNumbers = Console.ReadLine().Split().ToList();
            List<string> secondNumbers = Console.ReadLine().Split().ToList();
 
            int smallerList = Math.Min(firstNumbers.Count, secondNumbers.Count);
            int biggerList = Math.Max(firstNumbers.Count, secondNumbers.Count);
 
            List<int> mixedNumbers = new List<int>(8);
            for (int i = 0; i < smallerList; i++)
            {
                firstNumbers.Add(" ");
            }
            for (int i = 0; i < smallerList*2; i+= 2)
            {
                mixedNumbers.Insert(i, firstNumbers[i]);
            }
            
 
            for (int i = (smallerList*2)-1; i > 0; i-= 2)
            {
                mixedNumbers.Insert(i, secondNumbers[i]);
            }
 
            Console.WriteLine(string.Join(" ", mixedNumbers));
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Spaceship_Crafting
{
    class Program
    {
        public static int GlassCount;
        public static int AluminiumCount;
        public static int LithiumCount;
        public static int CarbonCount;
        public static Queue<int> chemicalLiquids;
        public static Stack<int> physicalItems;
        static void Main(string[] args)
        {
            int[] inputLiquids = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] inputItems = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            if (inputLiquids.Length>0)
            {
                chemicalLiquids = new Queue<int>(inputLiquids);
            }
            else
            {
                chemicalLiquids = new Queue<int>();
            }

            if (inputItems.Length>0)
            {
                chemicalLiquids = new Queue<int>(inputLiquids);
            }

            else
            {
                chemicalLiquids = new Queue<int>();
            }
            physicalItems = new Stack<int>(inputItems);
            while (chemicalLiquids.Count != 0 && physicalItems.Count != 0)
            {
                CheckIsValid(chemicalLiquids.Peek(), physicalItems.Peek());
            }

            if (GlassCount > 0 && AluminiumCount > 0 && LithiumCount > 0 && CarbonCount > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }

            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (chemicalLiquids.Any())
            {
                Console.WriteLine($"Liquids left: {String.Join(", ", chemicalLiquids)}");

            }

            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (physicalItems.Any())
            {
                Console.WriteLine($"Physical items left: {String.Join(", ", physicalItems)}");

            }

            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine($"Aluminium: {AluminiumCount}");
            Console.WriteLine($"Carbon fiber: {CarbonCount}");
            Console.WriteLine($"Glass: {GlassCount}");
            Console.WriteLine($"Lithium: {LithiumCount}");
           
           
                

        }

        private static void CheckIsValid(int chemical, int item)
        {
            int sum = chemical + item;

            if (sum == 25)
            {
                chemicalLiquids.Dequeue();
                physicalItems.Pop();
                GlassCount++;

            }

            else if (sum == 50)
            {
                chemicalLiquids.Dequeue();
                physicalItems.Pop();
                AluminiumCount++;
            }

            else if (sum == 75)
            {
                chemicalLiquids.Dequeue();
                physicalItems.Pop();
                LithiumCount++;
            }

            else if (sum == 100)
            {
                chemicalLiquids.Dequeue();
                physicalItems.Pop();
                CarbonCount++;
            }

            else
            {
                chemicalLiquids.Dequeue();
                physicalItems.Pop();
                item += 3;
                physicalItems.Push(item);
            }
        }
    }
}

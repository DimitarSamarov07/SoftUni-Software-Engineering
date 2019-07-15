using System;
using System.Collections.Generic;
using System.Linq;

namespace Make_a_Salad
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] inputVegetables = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int[] inputCalories = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<string> vegetables = new Queue<string>(inputVegetables); 
            Stack<int> calories = new Stack<int>(inputCalories);
            List<int> doneSalads = new List<int>(); 
           

            while (vegetables.Count != 0 && calories.Count != 0)
            {
                int currentCalories = calories.Peek();
                int currentValue = GetTypeOfVegetable(vegetables);
                while (currentCalories!=0)
                {
                    int fakeCase = calories.Peek();
                    currentCalories -= currentValue;
                    if (currentCalories<=0)
                    {
                        vegetables.Dequeue();
                        doneSalads.Add(calories.Pop());
                        break;
                    }

                    else
                    {
                        if (vegetables.Any())
                        {
                            vegetables.Dequeue();
                            if (vegetables.Any())
                            {
                                currentValue = GetTypeOfVegetable(vegetables);
                            }

                            else
                            { 
                                doneSalads.Add(fakeCase);
                                calories.Pop();
                                break;
                            }
                            
                        }

                        else
                        {
                            break;
                        }
                    }

                    
                }


            }

            Console.WriteLine(String.Join(" ",doneSalads));
            if (calories.Count>0)
            {
                Console.WriteLine(String.Join(" ",calories));
            }

            else if (vegetables.Count>0)
            {
                Console.WriteLine(String.Join(" ",vegetables));
            }


        }

        public static int GetTypeOfVegetable(Queue<string> vegetables)
        {
            int currentValue = 0;
            if (vegetables.Peek()=="tomato")
            {
                currentValue = 80;
            }

            else if (vegetables.Peek()=="carrot")
            {
                currentValue = 136;
            }

            else if (vegetables.Peek()=="lettuce")
            { 
                currentValue = 109;
            }
            
            else if (vegetables.Peek()=="potato")
            {
                currentValue = 215;
            }

            return currentValue;
        }

    }
}

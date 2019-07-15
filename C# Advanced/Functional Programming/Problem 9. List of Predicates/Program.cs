using System;
using System.Linq;

namespace Problem_9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int counter = 0;
            for (int i = 0; i <= range; i++)
            {
                counter = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i==0)
                    {
                        break;
                    }
                    if (i % numbers[j] == 0)
                    {
                        counter++;
                    }

                    if (counter==numbers.Length)
                    {
                        Console.Write(i+" ");
                        break;
                    }
                }
            }
        }
    }
}

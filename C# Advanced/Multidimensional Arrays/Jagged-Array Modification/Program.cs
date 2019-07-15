using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesOfArray = int.Parse(Console.ReadLine());
            int[][] jaged = new int[linesOfArray][];

            for (int row = 0; row < linesOfArray; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jaged[row] = input;
            }

            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line=="END")
                {
                    break;
                }
                string[] tokens = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (command == "Add")
                {
                    try
                    {
                        jaged[row][col] += value;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }

                else if (command == "Subtract")
                {
                    try
                    {
                        jaged[row][col] -= value;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }

            }

            foreach (int[] row in jaged)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }

    }
}

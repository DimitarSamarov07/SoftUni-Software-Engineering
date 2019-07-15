using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows,rows];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = line[c];
                }
            }
            int sum = 0;
            int count = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                sum += matrix[r, count];
                count++;
            }
            Console.WriteLine(sum);
            
        }
    }
}

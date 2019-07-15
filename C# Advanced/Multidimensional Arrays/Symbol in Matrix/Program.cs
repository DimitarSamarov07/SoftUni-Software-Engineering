using System;
using System.Linq;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rc = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rc,rc];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] line = Console.ReadLine()
                    .ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            char findMe = Console.ReadLine()[0];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r,c]==findMe)
                    {
                        Console.WriteLine($"({r}, {c})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{findMe} does not occur in the matrix ");
        }
    }
}

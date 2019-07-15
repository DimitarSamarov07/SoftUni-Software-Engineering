using System;
using System.Linq;

namespace Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[sizes[0],sizes[1]];
            int[,] biggestSquareMatrix = new int[2,2];
            int biggestSquareSum = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            for (int r = 0; r < matrix.GetLength(0)-1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1)-1; c++)
                {
                    var newSquare = matrix[r, c] + matrix[r + 1, c + 1] + matrix[r + 1, c] + matrix[r, c + 1];

                    if (newSquare>biggestSquareSum)
                    {
                        biggestSquareSum = newSquare;
                        biggestSquareMatrix[0, 0] = matrix[r, c];
                        biggestSquareMatrix[0, 1] = matrix[r, c + 1];
                        biggestSquareMatrix[1, 0] = matrix[r + 1, c];
                        biggestSquareMatrix[1, 1] = matrix[r + 1, c + 1];

                    }
                }
            }
            for (int r = 0; r < biggestSquareMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < biggestSquareMatrix.GetLength(1); c++)
                {
                    Console.Write(biggestSquareMatrix[r,c]+" ");
                }

                Console.WriteLine();
            }
            Console.WriteLine(biggestSquareSum);
        }
    }
}

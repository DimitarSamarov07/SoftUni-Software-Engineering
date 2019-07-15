using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows,cols] = line[cols];
                }
            }
            //First Diagonal
            int cols2 = 0;
            int firstSum = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                firstSum += matrix[rows, cols2];
                cols2++;
            }

            //Second Diagonal
            cols2 = matrix.GetLength(1)-1;
            int secondSum = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                secondSum += matrix[rows, cols2];
                cols2--;

            }
 
            int finalSum = firstSum - secondSum;

            if (finalSum<0)
            {
                finalSum *= -1;
                Console.WriteLine(finalSum);
            }

            else
            {
                Console.WriteLine(finalSum);
            }

            

        }
    }
}

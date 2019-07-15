using System;

namespace NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PrintMatrixWithGivenNumber(input);
        }

        private static void PrintMatrixWithGivenNumber(int input)
        {
            for (int row = 1; row <= input; row++)
            {
                for (int j = 1; j <= input; j++)
                {
                    Console.Write(input + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

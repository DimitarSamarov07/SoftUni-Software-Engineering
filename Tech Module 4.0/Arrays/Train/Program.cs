using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            string allElements = String.Empty;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
                allElements += currentNumber + " ";
            }
            Console.WriteLine(allElements);
            Console.WriteLine(sum);
        }
    }
}

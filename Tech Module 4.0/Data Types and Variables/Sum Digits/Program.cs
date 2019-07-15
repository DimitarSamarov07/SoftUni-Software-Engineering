using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int n1 = n;

            do
            {
                sum = sum + (n1 % 10);
                n1 = n1 / 10;
            }
            while (n1 > 0);

            Console.WriteLine(sum);
        }
    }
}
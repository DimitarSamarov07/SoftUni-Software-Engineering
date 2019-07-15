using System;

namespace Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int mi = int.Parse(Console.ReadLine());
            int j = int.Parse(Console.ReadLine());
            int sum = 0;
            string n= " ";
            string pesho = Environment.NewLine;
            for (int m = mi; m <= j; m++)
            {
                Console.Write($"{m} ");
                sum = sum + m;
                
            }
            Console.WriteLine(pesho);
            Console.WriteLine($"Sum: {sum}");
        }
    }

}
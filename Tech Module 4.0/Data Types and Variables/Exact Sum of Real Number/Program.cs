using System;


namespace Exact_Sum_of_Real_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;
            int kk = 0;
            for (int i = kk; i <=n; )
            {
                kk++;
                
                decimal number = decimal.Parse(Console.ReadLine());
                sum = sum + number;
                if (kk >= n)
                {
                    break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}

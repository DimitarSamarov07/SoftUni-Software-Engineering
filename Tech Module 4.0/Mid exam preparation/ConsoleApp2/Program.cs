using System;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger pesho = 99999 * 9999;
            while (true)
            {
                pesho *= 999999;
                Console.Write(pesho);
            }
            
        }
    }
}

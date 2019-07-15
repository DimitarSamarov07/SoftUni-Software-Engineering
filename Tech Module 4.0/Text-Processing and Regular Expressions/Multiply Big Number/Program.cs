using System;
using System.Numerics;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            BigInteger input2 = BigInteger.Parse(Console.ReadLine());
            BigInteger result = input * input2;
            Console.WriteLine(result);


        }
    }
}

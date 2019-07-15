using System;
using System.Linq;

namespace Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string reverse = new string(input.Reverse().ToArray());
            if (input == reverse)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            while (true)
            {
                input = Console.ReadLine();
                reverse = new string(input.Reverse().ToArray());
                if (input=="END")
                {
                    return;
                }
                if (input == reverse)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }



            }


        }
    }
}

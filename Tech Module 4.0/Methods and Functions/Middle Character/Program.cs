using System;

namespace Middle_Character
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddleCHars(input);
        }

        private static void PrintMiddleCHars(string input)
        {

            if (input.Length%2==0)
            {
                Console.WriteLine($"{input[input.Length/2-1]}{input[input.Length / 2]}");
            }

            else
            {
                Console.WriteLine($"{input[input.Length/2]}");
            }

        }
    }
}

using System;

namespace Sum_of_chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberofsymbols = int.Parse(Console.ReadLine());
            int sumofchars = 0;

            for (int i = 0; i < numberofsymbols; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                sumofchars += symbol;
            }
            Console.WriteLine($"The sum equals: {sumofchars}");

            
        }
    }
}

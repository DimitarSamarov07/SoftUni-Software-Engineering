using System;

namespace Print_Part_of_the_ASCII_table
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            int second = char.Parse(Console.ReadLine());

            for (int i = first; i <= second; i++)
            {
                Console.Write((char)i+" ");
                
            }


        }
    }
}

using System;

namespace Charecters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            PrintCharactersInRange(start, end);
        }

        private static void PrintCharactersInRange(char start, char end)
        {
           
            if (end<start)
            {
                char temp = start;
                start = end;
                end = temp;
                    
            }
            for (char i = (char)(start+1); i < end; i++)
            {
                Console.Write(i+" ");
            }
        }
    }
}

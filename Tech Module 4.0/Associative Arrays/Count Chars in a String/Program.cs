using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().Where(x => x != ' ').ToArray();

            var countChar = new Dictionary<char, int>();

            foreach (var character in text)
            {
                if (!countChar.ContainsKey(character))
                {
                    countChar[character] = 0;
                }
                countChar[character]++;
            }


            foreach (var kvp in countChar)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}

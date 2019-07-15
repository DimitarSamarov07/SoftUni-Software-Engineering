using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp219
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int strength = 0;
            char symbol = ' ';
            for (int i = 0; i < text.Length; i++)
            {
                symbol = text[i];
                if (symbol == '>')
                {
                    strength += int.Parse(text[i + 1].ToString());
                }

                else if (text[i] != '>' && strength > 0)
                {

                    text = text.Remove(i, 1);
                    strength--;
                    i--;
                }
            }
            Console.WriteLine(text);

        }
    }
}

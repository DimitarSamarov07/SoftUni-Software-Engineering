using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;


namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPattern = @"^[d-z{}|#]+$";
            string input = Console.ReadLine();
            string input2 = Console.ReadLine();
            List<string> listOfReplacements = input2.Split(" ").ToList();
            StringBuilder sb = new StringBuilder();
            bool isValid = Regex.IsMatch(input, textPattern);
            if (isValid)
            {
                foreach (char symbol in input)
                {
                    char current = (char)(symbol - 3);
                    sb.Append(current);
                }

                sb.Replace(listOfReplacements[0], listOfReplacements[1]);
            }

            else
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }
            Console.WriteLine(sb);
            
        }
    }
}

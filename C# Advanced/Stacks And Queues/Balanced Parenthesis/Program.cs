using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> skobi = new Stack<char>();
            bool balance = true;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == '(')
                {
                    skobi.Push(')');
                }
                else if (currentChar == '[')
                {
                    skobi.Push(']');
                }
                else if (currentChar == '{')
                {
                    skobi.Push('}');
                }
                else
                {
                    if (currentChar == ')')
                    {
                        if (!skobi.Any() || skobi.Pop() != ')')
                        {
                            balance = false;
                        }

                    }
                    if (currentChar == ']')
                    {
                        if (!skobi.Any() || skobi.Pop() != ']')
                        {
                            balance = false;
                        }
                    }
                    if (currentChar == '}')
                    {
                        if (!skobi.Any() || skobi.Pop() != '}')
                        {
                            balance = false;
                        }
                    }
                }



            }
            Console.WriteLine(balance ? "YES" : "NO");

        }
    }
}
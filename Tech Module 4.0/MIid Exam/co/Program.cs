using System;
using System.Collections.Generic;
using System.Linq;

namespace co
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> paints = Console.ReadLine().Split(" ").ToList();
            int index = 0;
            int index2 = 0;
            while (true)
            {
                List<string> input = Console.ReadLine().Split(" ").ToList();

                string Event = input[0];
                if (Event=="END")
                {
                    break;
                }
                else if (Event == "Change")
                {
                    if (paints.Contains(input[0]))
                    {
                        index = paints.IndexOf(input[1]);
                        paints.RemoveAt(index);
                        paints.Insert(index, input[2]);
                    }

                    else
                    {
                        continue;
                    }
                }

                else if (Event == "Hide")
                {
                    if (paints.Contains(input[1]))
                    {
                        index = paints.IndexOf(input[1]);
                        paints.RemoveAt(index);
                    }
                }
                else if (Event == "Switch")
                {
                    if (paints.Contains(input[1]) && paints.Contains(input[2]))
                    {
                        index = paints.IndexOf(input[1]);
                        index2 = paints.IndexOf(input[2]);
                        string first = input[1];
                        string second = input[2];

                        paints.RemoveAt(index);
                        paints.RemoveAt(index2);
                        paints.Insert(index2, first);
                        paints.Insert(index, second);

                    }
                }

                else if (Event=="Reverse")
                {
                    paints.Reverse();
                }
                else if (Event== "Insert")
                {
                    paints.Insert(int.Parse(input[1]), input[2]);
                }

            }
            Console.WriteLine(String.Join(" ",paints));
            
        }
    }
}

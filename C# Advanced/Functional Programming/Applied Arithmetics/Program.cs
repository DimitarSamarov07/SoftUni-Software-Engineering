using System;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func <long, long> add = n => n += 1;
            Func<long, long> multiply = n => n *= 2;
            Func<long, long> substract = n => n -= 1;
            Action<long[]> print = n => Console.Write(String.Join(" ",n));
            string command;
            long[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            while (true)
            {
                command = Console.ReadLine();
                if (command=="end")
                {
                    return;
                }
                else if (command=="add")
                {
                    for (long i = 0; i < input.Length; i++)
                    {

                        input[i]=add(input[i]);
                    }
                }

                else if (command == "multiply")
                {
                    for (long i = 0; i < input.Length; i++)
                    {
                        input[i]=multiply(input[i]);
                    }
                }

                else if (command == "subtract")
                {
                    for (long i = 0; i < input.Length; i++)
                    {
                        input[i] = substract(input[i]);
                    }
                }

                else if (command == "print")
                {
                    print(input);

                }
            }
        }
    }
}

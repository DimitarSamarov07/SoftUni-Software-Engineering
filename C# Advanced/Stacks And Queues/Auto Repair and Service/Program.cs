using System;
using System.Collections.Generic;
using System.Linq;

namespace Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Stack<string> served = new Stack<string>();
            Queue<string> waiting = new Queue<string>(line);

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (command[0] == "End")
                {
                    if (waiting.Count > 0)
                    {
                        Console.WriteLine($"Vehicles for service: {String.Join(", ", waiting)}");
                    }
                    Console.WriteLine($"Served vehicles: {String.Join(", ", served)}");
                    break;
                }
                if (command[0] == "Service")
                {
                    if (waiting.Count > 0)
                    {
                        string item = waiting.Dequeue();
                        served.Push(item);
                        Console.WriteLine($"Vehicle {item} got served.");
                    }

                }

                else if (command[0] == "CarInfo")
                {
                    string car = command[1];
                    if (waiting.Contains(car))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }

                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }

                else if (command[0] == "History")
                {
                    Console.WriteLine(String.Join(", ", served));
                }
            }


        }
    }
}

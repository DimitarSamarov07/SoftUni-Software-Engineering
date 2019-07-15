using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new Dictionary<string, int>();
            var prices = new Dictionary<string, double>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "buy")
            {



                List<string> commands = input.Split(" ").ToList();
                string name = commands[0];
                double price = double.Parse(commands[1]);
                int quantity = int.Parse(commands[2]);

                if (!orders.ContainsKey(name))
                {
                    orders[name] = quantity;
                    prices[name] = price;
                }

                else
                {
                    orders[name] += quantity;
                    prices[name] = price;
                }
            }
            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Key}"+ " -> "+$"{prices[item.Key] * item.Value:f2} "); 
            }
        }
    }
}

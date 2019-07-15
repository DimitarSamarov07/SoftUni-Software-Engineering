using System;
using System.Collections.Generic;
using System.Linq;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            var resources = new Dictionary<string, int>();
            string resource = String.Empty;
            while ((resource=Console.ReadLine())!="stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                {
                    resources[resource] = quantity;
                }
                else
                {
                    resources[resource] += quantity;
                }
            }

            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}

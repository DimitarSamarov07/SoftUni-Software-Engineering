using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();



            int capacityOfWagon = int.Parse(Console.ReadLine());
            string command;

            while ((command=Console.ReadLine())!="end")
            {
                
                List<string> directions = command
                .Split()
                .ToList();
                //Add 10

                if (directions[0]=="Add")
                {
                    int customersInWagon = int.Parse(directions[1]);
                       wagons.Add(customersInWagon);
                }

                else
                {
                    int PassengersToFit = int.Parse(directions[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i]+PassengersToFit<=capacityOfWagon)
                        {
                            wagons[i] += PassengersToFit;
                            break;
                        }
                    }

                }
                
                
            }

            Console.WriteLine(string.Join(" ", wagons));









        }
    }
}

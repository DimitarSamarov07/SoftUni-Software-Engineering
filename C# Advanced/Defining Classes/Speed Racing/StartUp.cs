using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Car> cars = new Dictionary<string, Car>();
            int carsToTrack = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsToTrack; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = line[0];
                double fuelAmount = double.Parse(line[1]);
                double fuelConsumption = double.Parse(line[2]);
                Car currentCar = new Car(model,fuelAmount,fuelConsumption);
                cars.Add(model,currentCar);
                
            }

            
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
                    }
                    return;
                }
                string[] line = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = line[0];
                string model = line[1];
                double amountOfKm = double.Parse(line[2]);
                double currentModelFuel = cars[model].FuelAmount;
                double currentModelConsumption = cars[model].FuelConsumptionPerKm;
                
                if(currentModelConsumption*amountOfKm<=currentModelFuel)
                {
                    cars[model].FuelAmount -= currentModelConsumption * amountOfKm;
                    cars[model].TravelledDistance += amountOfKm;
                }

                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                

            }
        }
    }
}

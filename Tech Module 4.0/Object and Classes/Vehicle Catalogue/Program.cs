using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        class Car
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public int HoursPoewr { get; set; }
        }

        class Truck
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public int HoursPoewr { get; set; }
        }

        class Catalog
        {
            public Catalog() // Конструктор
            {
                List<Car> Car = new List<Car>();
                List<Truck> Truck = new List<Truck>();
            }

            public List<Car> Cars { get; set; }
            public List<Truck> Trucks { get; set; }
        }
        static void Main(string[] args)
        {
            Catalog vehiclesCatalogue = new Catalog()
            {
                Cars = new List<Car>(),
                Trucks = new List<Truck>()
            };
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End")
                {
                    break;
                }

                string[] tokens = inputLine.Split();
                string typeVehicle = tokens[0];
                string model = tokens[1];
                string color = tokens[2];
                int hoursPoewr = int.Parse(tokens[3]);

                switch (typeVehicle)
                {
                    case "car":
                        Car oneCar = new Car()
                        {
                            Model = model,
                            Color = color,
                            HoursPoewr = hoursPoewr
                        };
                        vehiclesCatalogue.Cars.Add(oneCar);
                        break;
                    case "truck":
                        Truck oneTruck = new Truck()
                        {
                            Model = model,
                            Color = color,
                            HoursPoewr = hoursPoewr
                        };
                        vehiclesCatalogue.Trucks.Add(oneTruck);
                        break;
                }
            }

            while (true)
            {
                string inputModel = Console.ReadLine();
                if (inputModel == "Close the Catalogue")
                {
                    break;
                }

                string findModelCar = vehiclesCatalogue.Cars.Select(x => x.Model).ToString();
                string findModelTruck = vehiclesCatalogue.Trucks.Select(x => x.Model).ToString();

                if (findModelCar != null)
                {
                    foreach (var car in vehiclesCatalogue.Cars)
                    {
                        if (car.Model == inputModel)
                        {
                            Console.WriteLine("Type: Car");
                            Console.WriteLine($"Model: {car.Model}");
                            Console.WriteLine($"Color: {car.Color}");
                            Console.WriteLine($"Horsepower: {car.HoursPoewr}");
                        }
                    }
                }
                if (findModelTruck != null)
                {
                    foreach (var truck in vehiclesCatalogue.Trucks)
                    {
                        if (truck.Model == inputModel)
                        {
                            Console.WriteLine("Type: Truck");
                            Console.WriteLine($"Model: {truck.Model}");
                            Console.WriteLine($"Color: {truck.Color}");
                            Console.WriteLine($"Horsepower: {truck.HoursPoewr}");
                        }
                    }
                }
            }

            double averangeCarPoewr = 0;
            if (vehiclesCatalogue.Cars.Count != 0)
            {
                averangeCarPoewr = vehiclesCatalogue.Cars.Average(x => x.HoursPoewr);
            }
            double averangeTuckPoewr = 0;
            if (vehiclesCatalogue.Trucks.Count != 0)
            {
                averangeTuckPoewr = vehiclesCatalogue.Trucks.Average(x => x.HoursPoewr);
            }

            Console.WriteLine($"Cars have average horsepower of: {averangeCarPoewr:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averangeTuckPoewr:f2}.");
        }
    }
}
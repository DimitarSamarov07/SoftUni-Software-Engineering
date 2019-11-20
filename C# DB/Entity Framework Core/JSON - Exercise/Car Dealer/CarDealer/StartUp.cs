namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data;
    using DTO;
    using DTO.Export;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureCreated();

            var file = File.ReadAllText(
                @"D:\GitHub Local\SoftUni-Software-Engineering\C# DB\Entity Framework Core\JSON - Exercise\Car Dealer\CarDealer\Datasets\sales.json");

            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(x => x.SupplierId <= 31)
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<ImportCarsDto[]>(inputJson);

            foreach (var carDto in cars)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    if (context.Cars.FirstOrDefault(x => x.Id == car.Id) == null)
                    {
                        PartCar partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = partId
                        };


                        if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                        {
                            context.PartCars.Add(partCar);
                        }
                    }
                }

            }

            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }


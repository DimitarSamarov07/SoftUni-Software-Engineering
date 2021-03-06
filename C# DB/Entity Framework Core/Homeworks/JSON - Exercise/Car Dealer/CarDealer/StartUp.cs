﻿namespace CarDealer
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

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new ExportCustomerDto
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new ExportCarToyotaDto
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new ExportSuppliersDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(x => new
                {
                    car = new ExportCarDto
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance
                    },

                    parts = x.PartCars.Select(p => new ExportPartDto
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:f2}"
                    })
                        .ToArray()

                })
                .ToArray();


            var json = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
            return json;

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithCars = context.Customers
                .Select(x => new ExportCustomerWithCarDto
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(p => p.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToArray();

            var json = JsonConvert.SerializeObject(customersWithCars, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            return json;
        }


        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithCars = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new ExportCarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },

                    customerName = x.Customer.Name,
                    Discount = $"{x.Discount:f2}",
                    price = $"{x.Car.PartCars.Sum(p => p.Part.Price):f2}",
                    priceWithDiscount = $"{x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100:f2}"
                })
                .ToArray();
            
            var json = JsonConvert.SerializeObject(salesWithCars, Formatting.Indented);

            return json;

        }
    }


}
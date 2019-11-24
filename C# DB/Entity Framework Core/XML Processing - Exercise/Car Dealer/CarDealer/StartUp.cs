namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using AutoMapper;
    using AutoMapper.Configuration;
    using Data;
    using Dtos.Export;
    using Dtos.Import;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            CarDealerContext context = new CarDealerContext();
            context.Database.EnsureCreated();

            
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportSupplierDto[]),
                             new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSupplierDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Supplier> suppliers = new List<Supplier>();
            foreach (var supplierDto in suppliersDto)
            {
                var part = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(part);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Part> parts = new List<Part>();
            foreach (var partDto in partsDto)
            {
                var part = Mapper.Map<Part>(partDto);
                var target = context.Suppliers.Find(part.SupplierId);
                if (target != null)
                {
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            var carsDto = (ImportCarDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Car> cars = new List<Car>();
            foreach (var carDto in carsDto)
            {
                var car = Mapper.Map<Car>(carDto);
                context.Cars.Add(car);
                foreach (var dtoPartId in carDto.Parts.PartsId)
                {
                    var target = context.Parts.Find(dtoPartId.PartId);
                    var target1 = car.PartCars.FirstOrDefault(x => x.PartId == dtoPartId.PartId);
                    if (target != null && target1 == null)
                    {
                        var partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = dtoPartId.PartId
                        };
                        car.PartCars.Add(partCar);
                        context.PartCars.Add(partCar);
                    }

                }

                cars.Add(car);
            }
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                             new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Customer> customers = new List<Customer>();
            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            var salesDto = (ImportSaleDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Sale> sales = new List<Sale>();
            foreach (var saleDto in salesDto)
            {
                var target = context.Cars.Find(saleDto.CarId);
                if (target != null)
                {
                    var sale = Mapper.Map<Sale>(saleDto);
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .Select(x => new GetCarWithDistanceDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(GetCarWithDistanceDto[]),
                             new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder xml = new StringBuilder();

            serializer.Serialize(new StringWriter(xml), cars, namespaces);

            return xml.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new GetCarsFromMakeBmwDto
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(GetCarsFromMakeBmwDto[]),
                             new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder xml = new StringBuilder();

            serializer.Serialize(new StringWriter(xml), cars, namespaces);

            return xml.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new GetLocalSuppliersDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(GetLocalSuppliersDto[]),
                             new XmlRootAttribute("suppliers"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder xml = new StringBuilder();

            serializer.Serialize(new StringWriter(xml), suppliers, namespaces);

            return xml.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .Select(x => new GetCarWithListOfParts
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars
                        .Select(p => new GetPartMainInfo
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(z => z.Price)
                        .ToList()

                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(GetCarWithListOfParts[]),
                             new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder xml = new StringBuilder();

            serializer.Serialize(new StringWriter(xml), carsWithParts, namespaces);

            return xml.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count >= 1)
                .Select(x => new GetTotalSalesByCustomerDto
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(p => p.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            var serializer = new XmlSerializer(typeof(GetTotalSalesByCustomerDto[]),
                new XmlRootAttribute("customers"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder xml = new StringBuilder();

            serializer.Serialize(new StringWriter(xml), customers, namespaces);

            return xml.ToString();
        }


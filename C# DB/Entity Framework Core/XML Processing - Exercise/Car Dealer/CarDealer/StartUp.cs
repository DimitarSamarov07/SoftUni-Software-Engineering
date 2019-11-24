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


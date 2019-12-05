namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using ExportDtos;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new
                {
                    OwnerName = x.Passport.OwnerName,
                    AnimalName = x.Name,
                    Age = x.Age,
                    SerialNumber = x.PassportSerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy",
                        CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.Age)
                .ThenBy(x => x.SerialNumber)
                .ToArray();

            var json = JsonConvert.SerializeObject(animals, Formatting.Indented);

            return json.TrimEnd();
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .OrderBy(x => x.DateTime)
                .ThenBy(x => x.Animal.Passport.SerialNumber)
                .Select(x => new ExportProcedureDto
                {
                    Passport = x.Animal.Passport.SerialNumber,
                    OwnerNumber = x.Animal.Passport.OwnerPhoneNumber,
                    DateTime = x.DateTime
                        .ToString("dd-MM-yyyy",
                            CultureInfo.InvariantCulture),
                    AnimalAids = x.ProcedureAnimalAids
                        .Select(z => new ExportAnimalAidDto
                        {
                            Name = z.AnimalAid.Name,
                            Price = z.AnimalAid.Price
                        })
                        .ToArray(),
                    TotalPrice = x.ProcedureAnimalAids
                        .Sum(o=>o.AnimalAid.Price)
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportProcedureDto[]),
                new XmlRootAttribute("Procedures"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), procedures, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}

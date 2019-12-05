namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using ImportDtos;
    using Models;
    using Newtonsoft.Json;
    using PetClinic.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data.";
        private const string AnimalAidsSuccessMessage = "Record {0} successfully imported.";
        private const string AnimalsSuccessMessage = "Record {0} Passport №: {1} successfully imported.";
        private const string VetSuccessMessage = "Record {0} successfully imported.";
        private const string ProcedureSuccessMessage = "Record successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var toImport = JsonConvert.DeserializeObject<ImportAnimalAidDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (var animalAidsDto in toImport)
            {
                var animalAid = new AnimalAid
                {
                    Name = animalAidsDto.Name,
                    Price = animalAidsDto.Price
                };

                var check1 = IsValid(animalAid);
                var check2 = context.AnimalAids.FirstOrDefault(x => x.Name == animalAid.Name) == null;

                if (check1 && check2)
                {
                    context.AnimalAids.Add(animalAid);
                    context.SaveChanges();

                    sb.AppendLine(String.Format(AnimalAidsSuccessMessage,
                        animalAid.Name));
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var toImport = JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (var animalDto in toImport)
            {
                var animal = new Animal
                {
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                    Age = animalDto.Age,
                    PassportSerialNumber = animalDto.Passport.SerialNumber,
                    Passport = new Passport
                    {
                        SerialNumber = animalDto.Passport.SerialNumber,
                        OwnerName = animalDto.Passport.OwnerName,
                        OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                        RegistrationDate = DateTime.ParseExact(animalDto.Passport.RegistrationDate,
                            "dd-MM-yyyy",
                            CultureInfo.InvariantCulture)
                    }
                };

                var check = IsValid(animal);
                var check1 = IsValid(animal.Passport);
                var check2 = context.Passports
                    .FirstOrDefault(x => x.SerialNumber == animal.Passport.SerialNumber) == null;

                if (check && check1 && check2)
                {
                    context.Passports.Add(animal.Passport);
                    context.Animals.Add(animal);
                    context.SaveChanges();

                    sb.AppendLine(String.Format(AnimalsSuccessMessage,
                        animal.Name,
                        animal.Passport.SerialNumber));
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportVetDto[]),
                new XmlRootAttribute("Vets"));

            var toImport = (ImportVetDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            foreach (var vetDto in toImport)
            {
                var vet = new Vet
                {
                    Name = vetDto.Name,
                    Profession = vetDto.Profession,
                    Age = vetDto.Age,
                    PhoneNumber = vetDto.PhoneNumber
                };

                var check = IsValid(vet);
                var check1 = context.Vets.FirstOrDefault(x => x.PhoneNumber == vet.PhoneNumber) == null;

                if (check && check1)
                {
                    context.Vets.Add(vet);
                    context.SaveChanges();
                    sb.AppendLine(String.Format(VetSuccessMessage,
                        vet.Name));
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProcedureDto[]),
                new XmlRootAttribute("Procedures"));

            var toImport = (ImportProcedureDto[])serializer
                .Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            foreach (var procedureDto in toImport)
            {
                var check = context.Vets
                                .FirstOrDefault(x => x.Name == procedureDto.Vet) != null;

                var check1 = context.Passports
                                 .FirstOrDefault(x => x.SerialNumber == procedureDto.Animal) != null;

                var check2 = procedureDto.AnimalAids
                    .All(x => context.AnimalAids
                                  .FirstOrDefault(z => z.Name == x.Name) != null);

                var check3 =
                    procedureDto.AnimalAids.All(x => procedureDto.AnimalAids.Count(o => o.Name == x.Name) == 1);

                

                if (check && check1 && check2 && check3)
                {
                    var targetedVet = context.Vets
                        .FirstOrDefault(x => x.Name == procedureDto.Vet);

                    var targetedAnimal = context.Animals
                        .FirstOrDefault(x => x.Passport.SerialNumber == procedureDto.Animal);

                    var targetedAids = context.AnimalAids
                        .Where(x => procedureDto.AnimalAids
                            .Any(z => z.Name == x.Name))
                        .ToArray();

                    var procedure = new Procedure
                    {
                        Vet = targetedVet,
                        Animal = targetedAnimal,
                        DateTime = DateTime.ParseExact(procedureDto.DateTime,
                            "dd-MM-yyyy",
                            CultureInfo.InvariantCulture),
                        ProcedureAnimalAids = targetedAids.Select(x => new ProcedureAnimalAid
                        {
                            AnimalAid = x
                        })
                            .ToArray(),

                    };

                    if (!IsValid(procedure))
                    {
                        sb.AppendLine(ErrorMessage);
                    }

                    context.Procedures.Add(procedure);
                    context.SaveChanges();
                    sb.AppendLine(ProcedureSuccessMessage);
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}

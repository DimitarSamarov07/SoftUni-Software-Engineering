namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string DepartmentCellsSuccessMessage = "Imported {0} with {1} cells";
        private const string PrisonerMailsSuccessMassage = "Imported {0} {1} years old";
        private const string OfficersPrisonersSuccessMessage = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var toImport = JsonConvert.DeserializeObject<ImportDepartmentCellsDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (var dto in toImport)
            {
                var department = new Department
                {
                    Name = dto.Name
                };

                var check = IsValid(department);
                var check1 = dto.Cells.All(x => IsValid(new Cell
                {
                    CellNumber = x.CellNumber,
                    HasWindow = x.HasWindow
                }));

                if (check && check1)
                {
                    foreach (var cellDto in dto.Cells)
                    {
                        var cell = new Cell
                        {
                            CellNumber = cellDto.CellNumber,
                            HasWindow = cellDto.HasWindow
                        };


                        context.Cells.Add(cell);
                        department.Cells.Add(cell);
                    }

                    context.Departments.Add(department);
                    sb.AppendLine(String.Format(DepartmentCellsSuccessMessage,
                        department.Name,
                        department.Cells.Count));
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var toImport = JsonConvert.DeserializeObject<ImportPrisonerMailsDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (var prisonerDto in toImport)
            {
                if (prisonerDto.IncarcerationDate != null)
                {
                    var prisoner = new Prisoner
                    {
                        FullName = prisonerDto.FullName,
                        Nickname = prisonerDto.Nickname,
                        Age = prisonerDto.Age,

                        IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate,
                            "dd/MM/yyyy", CultureInfo.InvariantCulture),

                        Bail = prisonerDto.Bail,
                        CellId = prisonerDto.CellId,

                        Mails = prisonerDto.Mails.Select(x => new Mail
                        {
                            Description = x.Description,
                            Sender = x.Sender,
                            Address = x.Address
                        })
                            .ToArray()
                    };
                    if (prisonerDto.ReleaseDate != null)
                    {
                        prisoner.ReleaseDate = DateTime.ParseExact(prisonerDto.IncarcerationDate,
                            "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    var check = IsValid(prisoner);
                    var check1 = prisoner.Mails.All(IsValid);

                    if (check && check1)
                    {
                        foreach (var mail in prisoner.Mails)
                        {
                            context.Mails.Add(mail);
                        }

                        context.Prisoners.Add(prisoner);

                        sb.AppendLine(String.Format(PrisonerMailsSuccessMassage,
                            prisoner.FullName,
                            prisoner.Age));
                    }

                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }

            }

            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportOfficerPrisoners[]),
                new XmlRootAttribute("Officers"));

            var toImport = (ImportOfficerPrisoners[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            foreach (var dto in toImport)
            {
                Position position;
                Weapon weapon;

                Enum.TryParse(dto.Position, false ,out position);
                Enum.TryParse(dto.Weapon, out weapon);

                var officer = new Officer
                {
                    FullName = dto.Name,
                    Salary = dto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = dto.DepartmentId,
                    OfficerPrisoners = dto.Prisoners
                        .Select(x => new OfficerPrisoner
                        {
                            PrisonerId = x.Id
                        })
                        .ToArray()
                };

                bool check = position != default && weapon != default;
                bool check1 = IsValid(officer);

                if (check&&check1)
                {
                    context.Officers.Add(officer);
                    sb.AppendLine(String.Format(OfficersPrisonersSuccessMessage,
                        officer.FullName,
                        officer.OfficerPrisoners.Count));
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResults, true);
        }
    }
}
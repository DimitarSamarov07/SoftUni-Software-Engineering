namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Data.Models;
    using ImportDto;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var toImport = JsonConvert.DeserializeObject<Movie[]>(jsonString);

            StringBuilder result = new StringBuilder();
            foreach (var movie in toImport)
            {
                var target = context.Movies.FirstOrDefault(x => x.Title == movie.Title);

                var isValid = IsValid(movie);

                if (isValid && target == null)
                {
                    context.Movies.Add(movie);
                    result.AppendLine(String.Format(SuccessfulImportMovie, movie.Title, movie.Genre,$"{movie.Rating:f2}"));
                }

                else
                {
                    result.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var toImport = JsonConvert.DeserializeObject<ImportHallSeatsDto[]>(jsonString);

            StringBuilder result = new StringBuilder();
            foreach (var hallSeatsDto in toImport)
            {
                var hall = Mapper.Map<Hall>(hallSeatsDto);

                var check1 = IsValid(hallSeatsDto);
                var check2 = IsValid(hall);

                if (check1 && check2)
                {

                    for (int i = 0; i < hallSeatsDto.SeatsCount; i++)
                    {
                        hall.Seats.Add(new Seat());
                    }

                    if (hall.Is3D && !hall.Is4Dx)
                    {
                        result.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, "3D", hallSeatsDto.SeatsCount));
                    }

                    else if (!hall.Is3D && hall.Is4Dx)
                    {
                        result.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, "4Dx", hallSeatsDto.SeatsCount));

                    }

                    else if (hall.Is3D && hall.Is4Dx)
                    {
                        result.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, "4Dx/3D", hallSeatsDto.SeatsCount));

                    }

                    else
                    {
                        result.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, "Normal", hallSeatsDto.SeatsCount));

                    }

                    context.Halls.Add(hall);
                }

                else
                {
                    result.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProjectionDto[]),
                           new XmlRootAttribute("Projections"));


            var toImport = (ImportProjectionDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder result = new StringBuilder();
            foreach (var projectionDto in toImport)
            {
                var projection = Mapper.Map<Projection>(projectionDto);

                bool check = IsValid(projection);
                var target1 = context.Movies.FirstOrDefault(x => x.Id == projection.MovieId);
                var target2 = context.Halls.FirstOrDefault(x => x.Id == projection.HallId);

                if (check && target1 != null && target2 != null)
                {
                    context.Projections.Add(projection);
                    result.AppendLine(String.Format(SuccessfulImportProjection,
                        projection.Movie.Title,
                        projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                }

                else
                {
                    result.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportCustomerTicketsDto[]),
                             new XmlRootAttribute("Customers"));

            var toImport = (ImportCustomerTicketsDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder result = new StringBuilder();
            foreach (var customerWithTicketsDto in toImport)
            {
                var customerWithTickets = Mapper.Map<Customer>(customerWithTicketsDto);

                bool check1 = IsValid(customerWithTickets);

                if (check1)
                {
                    context.Customers.Add(customerWithTickets);

                    foreach (var ticket in customerWithTickets.Tickets)
                    {
                        context.Tickets.Add(ticket);
                    }

                    result.AppendLine(String.Format(SuccessfulImportCustomerTicket,
                                                    customerWithTickets.FirstName,
                                                    customerWithTickets.LastName,
                                                    customerWithTickets.Tickets.Count));
                }

                else
                {
                    result.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
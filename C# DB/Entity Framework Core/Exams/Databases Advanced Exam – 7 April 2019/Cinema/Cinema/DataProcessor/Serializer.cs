namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections
                                .Any(z => z.Tickets.Count >= 1))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(p => p.Tickets.Sum(z => z.Price)))
                .Take(10)
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = $"{x.Rating:f2}",
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(z => z.Price)).ToString("F2"),
                    Customers = x.Projections
                        .SelectMany(z => z.Tickets)
                            .Select(p => new
                            {
                                FirstName = p.Customer.FirstName,
                                LastName = p.Customer.LastName,
                                Balance = $"{p.Customer.Balance:f2}"
                            })
                            .OrderByDescending(o => o.Balance)
                            .ThenBy(o => o.FirstName)
                            .ThenBy(o => o.LastName)
                        .ToList()

                })
                .ToList();

            var output = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return output;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var serializer = new XmlSerializer(typeof(ExportCustomerDto[]),
                             new XmlRootAttribute("Customers"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var customers = context.Customers
                .Where(x => x.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(p => p.Price))
                .Select(x => new ExportCustomerDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(p => p.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromMilliseconds(x.Tickets.Sum(z => z.Projection.Movie.Duration.TotalMilliseconds))
                        .ToString(@"hh\:mm\:ss")
                })
                .Take(10)
                .ToArray();

            StringBuilder result = new StringBuilder();


            serializer.Serialize(new StringWriter(result), customers, namespaces);

            return result.ToString().TrimEnd();
        }
    }
}
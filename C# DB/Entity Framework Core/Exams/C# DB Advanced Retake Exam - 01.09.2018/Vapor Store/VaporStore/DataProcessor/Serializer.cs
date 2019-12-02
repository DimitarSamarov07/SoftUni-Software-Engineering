namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Data.Enums;
    using Data.Models;
    using ExportDtos;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .Where(x => genreNames.Contains(x.Name) && x.Games.Any())
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                        .Where(r => r.Purchases.Any())
                        .Select(z => new
                        {
                            Id = z.Id,
                            Title = z.Name,
                            Developer = z.Developer.Name,
                            Tags = String.Join(", ", z.GameTags.Select(r => r.Tag.Name)),
                            Players = z.Purchases.Count
                        })
                        .OrderByDescending(r => r.Players)
                        .ThenBy(r => r.Id)
                        .ToArray(),
                    TotalPlayers = x.Games.Sum(r => r.Purchases.Count)
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            var xml = JsonConvert.SerializeObject(games, Formatting.Indented);

            return xml.TrimEnd();

        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .Select(x => new ExportUserDto
                {
                    Username = x.Username,
                    Purchases = x.Cards
                        .SelectMany(r => r.Purchases)
                        .Where(o => o.Type.ToString() == storeType)
                        .Select(z => new ExportPurchaseDto
                        {
                            Card = z.Card.Number,
                            Cvc = z.Card.Cvc,
                            Date = z.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto
                            {
                                Title = z.Game.Name,
                                Genre = z.Game.Genre.Name,
                                Price = z.Game.Price
                            }
                        })
                        .OrderBy(o => o.Date)
                        .ToArray(),

                    TotalSpent = x.Cards
                        .Sum(r => r.Purchases
                            .Where(j => j.Type.ToString() == storeType)
                        .Sum(k => k.Game.Price))
                })
                .Where(p => p.Purchases.Any())
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportUserDto[]),
                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
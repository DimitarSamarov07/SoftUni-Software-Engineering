namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Castle.Core.Internal;
    using Data;
    using Data.Enums;
    using Data.Models;
    using ImportDtos;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string ImportGamesSuccessMessage = "Added {0} ({1}) with {2} tags";
        private const string ImportUsersSuccessMessage = "Imported {0} with {1} cards";
        private const string ImportPurchasesSuccessMessage = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var toImport = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (var gameDto in toImport)
            {
                var genre = context.Genres.FirstOrDefault(x => x.Name == gameDto.Genre);

                var developer = context.Developers.FirstOrDefault(x => x.Name == gameDto.Developer);

                if (!IsValid(gameDto) || !gameDto.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    context.Developers.Add(developer);

                }

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };
                    context.Genres.Add(genre);

                }

                var tags = new List<Tag>();
                foreach (var tagName in gameDto.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == tagName);

                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = tagName
                        };

                        context.Tags.Add(tag);
                    }

                    tags.Add(tag);
                }


                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate,
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                    GameTags = tags.Select(x => new GameTag { Tag = x }).ToHashSet()
                };

                context.Games.Add(game);
                context.SaveChanges();

                sb.AppendLine(String.Format(ImportGamesSuccessMessage,
                    game.Name,
                    gameDto.Genre,
                    game.GameTags.Count));
            }
            return sb.ToString();

        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var toImport = JsonConvert.DeserializeObject<ImportUserCardsDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (var userCardsDto in toImport)
            {
                var user = Mapper.Map<User>(userCardsDto);

                var check = IsValid(user);
                var check1 = userCardsDto.CardDtos.All(x => IsValid(Mapper.Map<Card>(x)));
                if (check && check1)
                {
                    foreach (var importCardDto in userCardsDto.CardDtos)
                    {
                        var card = Mapper.Map<Card>(importCardDto);

                        user.Cards.Add(card);
                    }

                    context.Users.Add(user);

                    sb.AppendLine(String.Format(ImportUsersSuccessMessage,
                        user.Username,
                        user.Cards.Count));
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportPurchaseDto[]),
                new XmlRootAttribute("Purchases"));

            var toImport = (ImportPurchaseDto[]) serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            foreach (var purchaseDto in toImport)
            {
                if (IsValid(purchaseDto))
                {
                    var user = context.Users.First(x=>x.Cards.Any(z=>z.Number==purchaseDto.Card));

                    var purchase = new Purchase
                    {
                        Game = context.Games.First(x => x.Name == purchaseDto.Title),
                        Card = context.Cards.First(x => x.Number == purchaseDto.Card),
                        Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                        ProductKey = purchaseDto.Key,
                        Type = Enum.Parse<PurchaseType>(purchaseDto.Type)
                    };

                    context.Purchases.Add(purchase);

                    sb.AppendLine(String.Format(ImportPurchasesSuccessMessage, purchaseDto.Title, user.Username));
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
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
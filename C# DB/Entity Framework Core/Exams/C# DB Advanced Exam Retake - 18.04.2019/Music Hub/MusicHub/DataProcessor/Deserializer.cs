namespace MusicHub.DataProcessor
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
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDtos;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var toImport = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (var writerDto in toImport)
            {
                var writer = Mapper.Map<Writer>(writerDto);

                bool check = IsValid(writer);

                if (check)
                {
                    context.Writers.Add(writer);
                    sb.AppendLine(String.Format(SuccessfullyImportedWriter, writer.Name));
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producers = JsonConvert.DeserializeObject<ImportProducerAlbumsDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (var producerAlbumsDto in producers)
            {
                var producerAlbums = new Producer
                {
                    Name = producerAlbumsDto.Name,
                    Pseudonym = producerAlbumsDto.Pseudonym,
                    PhoneNumber = producerAlbumsDto.PhoneNumber
                };

                bool check = IsValid(producerAlbums);

                if (check)
                {
                    bool check1 = true;
                    foreach (var albumDto in producerAlbumsDto.AlbumDtos)
                    {
                        var album = new Album
                        {
                            Name = albumDto.Name,
                            ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        };

                        check1 = IsValid(album);
                        if (!check1)
                        {
                            break;
                        }

                        producerAlbums.Albums.Add(album);
                    }


                    if (check1)
                    {
                        context.Producers.Add(producerAlbums);

                        if (producerAlbums.PhoneNumber != null)
                        {
                            sb.AppendLine(String.Format(SuccessfullyImportedProducerWithPhone,
                                producerAlbums.Name,
                                producerAlbums.PhoneNumber,
                                producerAlbums.Albums.Count));

                        }

                        else
                        {
                            sb.AppendLine(String.Format(SuccessfullyImportedProducerWithNoPhone,
                                producerAlbums.Name,
                                producerAlbums.Albums.Count));
                        }
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

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportSongDto[]),
                             new XmlRootAttribute("Songs"));

            var toImport = (ImportSongDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            foreach (var songDto in toImport)
            {

                bool check = context.Albums.Find(songDto.AlbumId) != null;
                bool check1 = context.Writers.Find(songDto.WriterId) != null;
                bool check2 = Enum.IsDefined(typeof(Genre), songDto.Genre);

                if (check && check1 && check2)
                {
                    var song = new Song
                    {
                        Name = songDto.Name,
                        Duration = TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture),
                        CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Genre = Enum.Parse<Genre>(songDto.Genre),
                        AlbumId = songDto.AlbumId,
                        WriterId = songDto.WriterId,
                        Price = songDto.Price
                    };

                    bool check3 = IsValid(song);
                    if (check3)
                    {
                        context.Songs.Add(song);
                        sb.AppendLine(String.Format(SuccessfullyImportedSong,
                            song.Name,
                            song.Genre,
                            song.Duration.ToString("c")));
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

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportSongPerformerDto[]),
                             new XmlRootAttribute("Performers"));

            var toImport = (ImportSongPerformerDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            foreach (var songPerformerDto in toImport)
            {
                var songPerformer = new Performer
                {
                    FirstName = songPerformerDto.FirstName,
                    LastName = songPerformerDto.LastName,
                    Age = songPerformerDto.Age,
                    NetWorth = songPerformerDto.NetWorth
                };

                bool check = IsValid(songPerformer);
                bool check1 = songPerformerDto.PerformersSong.All(x => context.Songs.Find(x.Id) != null);

                if (check && check1)
                {

                    songPerformer.PerformerSongs = songPerformerDto.PerformersSong
                        .Select(ps => new SongPerformer { SongId = ps.Id })
                        .ToList();


                    context.Performers.Add(songPerformer);

                    sb.AppendLine(String.Format(SuccessfullyImportedPerformer,
                                                songPerformer.FirstName,
                                                songPerformer.PerformerSongs.Count));
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
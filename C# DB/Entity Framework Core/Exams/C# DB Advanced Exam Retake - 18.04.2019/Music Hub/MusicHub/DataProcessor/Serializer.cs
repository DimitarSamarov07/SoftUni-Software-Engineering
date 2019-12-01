namespace MusicHub.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using ExportDtos;
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(z => new
                    {
                        SongName = z.Name,
                        Price = z.Price.ToString("F2"),
                        Writer = z.Writer.Name
                    })
                        .OrderByDescending(p => p.SongName)
                        .ThenBy(p => p.Writer)
                        .ToArray(),

                    AlbumPrice = x.Songs.Sum(r => r.Price).ToString("F2")
                })
                .OrderByDescending(x => decimal.Parse(x.AlbumPrice))
                .ToArray();

            var json = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return json;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new ExportSongDto
                {
                    SongName = x.Name,
                    Writer = x.Writer.Name,
                    Performer = x.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c")
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportSongDto[]),
                             new XmlRootAttribute("Songs"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty, });

            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), songs, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
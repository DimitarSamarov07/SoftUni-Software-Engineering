namespace MusicHub.DataProcessor.ImportDtos
{
    using Newtonsoft.Json;

    public class ImportProducerAlbumsDto
    {
        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public string PhoneNumber { get; set; }

        [JsonProperty("Albums")]
        public ImportAlbumDto[] AlbumDtos { get; set; }
    }
}

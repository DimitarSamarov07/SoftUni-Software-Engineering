namespace VaporStore.DataProcessor.ImportDtos
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ImportUserCardsDto
    {
        public string FullName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        [JsonProperty("Cards")]
        public ImportCardDto[] CardDtos { get; set; }
    }
}

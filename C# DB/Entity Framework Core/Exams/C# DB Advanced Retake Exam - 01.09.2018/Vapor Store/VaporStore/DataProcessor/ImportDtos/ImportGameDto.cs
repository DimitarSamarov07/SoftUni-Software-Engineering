namespace VaporStore.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Newtonsoft.Json;

    public class ImportGameDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string[] Tags { get; set; }
    }
}

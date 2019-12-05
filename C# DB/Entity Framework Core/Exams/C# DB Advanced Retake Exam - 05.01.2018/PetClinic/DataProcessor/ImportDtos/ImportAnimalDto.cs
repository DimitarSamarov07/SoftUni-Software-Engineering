namespace PetClinic.DataProcessor.ImportDtos
{
    public class ImportAnimalDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public ImportPassportDto Passport { get; set; }
    }
}

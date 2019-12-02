namespace VaporStore.DataProcessor.ImportDtos
{
    using Data.Enums;

    public class ImportCardDto
    {
        public string Number { get; set; }

        public string Cvc { get; set; }

        public CardType Type { get; set; }
    }
}

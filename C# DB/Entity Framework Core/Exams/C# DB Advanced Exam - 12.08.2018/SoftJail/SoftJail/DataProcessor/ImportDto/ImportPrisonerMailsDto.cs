namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonerMailsDto
    {
        public string FullName { get; set; }

        public string Nickname { get; set; }

        public int Age { get; set; }

        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int CellId { get; set; }

        public ImportMailDto[] Mails { get; set; }
    }
}

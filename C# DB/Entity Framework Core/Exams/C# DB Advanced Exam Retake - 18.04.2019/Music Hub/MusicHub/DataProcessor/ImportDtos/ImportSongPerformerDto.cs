namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Linq;
    using System.Xml.Serialization;

    [XmlType("Performer")]
    public class ImportSongPerformerDto
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("NetWorth")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public ImportSongIdDto[] PerformersSong { get; set; }
    }
}

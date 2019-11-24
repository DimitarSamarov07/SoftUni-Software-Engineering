namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlRoot("parts")]
    public class ImportPartsDto
    {
        [XmlElement(ElementName = "partId")]
        public ImportPartIdDto[] PartsId { get; set; }
    }
}

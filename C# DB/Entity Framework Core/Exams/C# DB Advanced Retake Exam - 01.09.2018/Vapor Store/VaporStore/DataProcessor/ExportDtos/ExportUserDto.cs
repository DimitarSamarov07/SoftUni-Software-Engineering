namespace VaporStore.DataProcessor.ExportDtos
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public ExportPurchaseDto[] Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}

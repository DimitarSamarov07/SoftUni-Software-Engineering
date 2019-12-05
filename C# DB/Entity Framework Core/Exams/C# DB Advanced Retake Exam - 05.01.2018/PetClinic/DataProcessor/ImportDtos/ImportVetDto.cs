namespace PetClinic.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Vet")]
    public class ImportVetDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Profession")]
        public string Profession { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}

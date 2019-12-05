namespace PetClinic.DataProcessor.ImportDtos
{
    using System.Xml.Linq;
    using System.Xml.Serialization;

    [XmlType("AnimalAid")]
    public class ImportAnimalAidName
    {
        public string Name { get; set; }
    }
}

namespace ProductShop.Dtos.Export
{
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    
    public class GetCountAndProductResultDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<GetSoldProductsAndCountDto> Users { get; set; }
    }
}

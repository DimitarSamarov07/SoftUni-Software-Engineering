namespace ProductShop.Dtos.Export
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class GetCountAndProducts
    {
        
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<GetShortProductInfo> Products { get; set; }
    }
}

using System.Xml.Serialization;

namespace Dade.Dms.Website.Configuration.Rest
{
    [XmlRoot("rest")]
    public class RestConfig
    {
        [XmlElement("pageSize")]
        public int PageSize { get; set; }
    }
}

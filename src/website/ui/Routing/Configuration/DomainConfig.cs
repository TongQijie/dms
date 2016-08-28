using System.Xml.Serialization;

namespace Dade.Dms.Website.Routing.Configuration
{
    public class DomainConfig
    {
        [XmlAttribute("enableSubdomain")]
        public bool EnableSubdomain { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}


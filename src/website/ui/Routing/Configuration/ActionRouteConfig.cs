using System.Xml.Serialization;

namespace Dade.Dms.Website.Routing.Configuration
{
    public class ActionRouteConfig
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("readable")]
        public string Readable { get; set; }

        [XmlAttribute("default")]
        public bool IsDefault { get; set; }
    }
}


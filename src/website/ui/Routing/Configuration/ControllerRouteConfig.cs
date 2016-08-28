using System.Xml.Serialization;

namespace Dade.Dms.Website.Routing.Configuration
{
    public class ControllerRouteConfig
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("default")]
        public bool IsDefault { get; set; }

        [XmlElement("action")]
        public ActionRouteConfig[] ActionRoutes { get; set; }
    }
}
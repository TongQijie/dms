using System.Xml.Serialization;

namespace Dade.Dms.Website.Routing.Configuration
{
    public class UnitRouteConfig
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlArray("domains")]
        [XmlArrayItem("domain")]
        public DomainConfig[] Domains { get; set; }

        [XmlArray("controllers")]
        [XmlArrayItem("controller")]
        public ControllerRouteConfig[] ControllerRoutes { get; set; }
    }
}
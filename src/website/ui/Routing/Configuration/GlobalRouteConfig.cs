using System.Xml.Serialization;

namespace Dade.Dms.Website.Routing.Configuration
{
    [XmlRoot("route")]
    public class GlobalRouteConfig
    {
        [XmlElement("unit")]
        public UnitRouteConfig[] UnitRoutes { get; set; }
    }
}
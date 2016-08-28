using System.Xml.Serialization;

namespace Dade.Dms.Website.Configuration.UI
{
    public class ResourceConfig
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}

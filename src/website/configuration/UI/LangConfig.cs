using System.Xml.Serialization;

namespace Dade.Dms.Website.Configuration.UI
{
    public class LangConfig
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("res")]
        public ResourceConfig[] Resources { get; set; }
    }
}

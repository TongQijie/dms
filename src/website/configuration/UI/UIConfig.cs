using System.Xml.Serialization;

namespace Dade.Dms.Website.Configuration.UI
{
    [XmlRoot("ui")]
    public class UIConfig
    {
        [XmlElement("defaultLang")]
        public string DefaultLang { get; set; }

        [XmlElement("lang")]
        public LangConfig[] Languages { get; set; }
    }
}

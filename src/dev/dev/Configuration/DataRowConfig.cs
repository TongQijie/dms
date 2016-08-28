using System.Xml.Serialization;

namespace Dade.Dms.Dev.Configuration
{
    public class DataRowConfig
    {
        [XmlAttribute("collectorId")]
        public string CollectorId { get; set; }

        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }

        [XmlElement("field")]
        public DataFieldConfig[] Fields { get; set; }
    }
}

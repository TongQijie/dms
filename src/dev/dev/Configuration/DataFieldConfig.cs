using System.Xml.Serialization;

namespace Dade.Dms.Dev.Configuration
{
    public class DataFieldConfig
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("dbRef")]
        public string DbRef { get; set; }

        [XmlAttribute("dataType")]
        public string DataType { get; set; }

        [XmlAttribute("defaultValue")]
        public string DefaultValue { get; set; }

        [XmlAttribute("format")]
        public string Format { get; set; }
    }
}

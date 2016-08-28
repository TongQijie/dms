using System.Xml.Serialization;

namespace Dade.Dms.Opc.Model
{
    public class DataChangeItem
    {
        [XmlElement("clientHandle")]
        public string ClientHandle { get; set; }

        [XmlElement("itemValue")]
        public string ItemValue { get; set; }

        [XmlElement("quality")]
        public string Quality { get; set; }

        [XmlElement("timestamp")]
        public string Timestamp { get; set; }
    }
}
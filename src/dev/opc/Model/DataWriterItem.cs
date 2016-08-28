using System.Xml.Serialization;

namespace Dade.Dms.Opc.Model
{
    public class DataWriterItem
    {
        [XmlElement("serverHandle")]
        public int ServerHandle { get; set; }

        [XmlElement("itemValue")]
        public string ItemValue { get; set; }
    }
}

using System.Xml.Serialization;

namespace Dade.Dms.Opc.Model
{
    [XmlRoot("dataWriter")]
    public class DataWriterPackage
    {
        [XmlAttribute("transactionId")]
        public int TransactionId { get; set; }

        [XmlElement("item")]
        public DataWriterItem[] Items { get; set; }
    }
}

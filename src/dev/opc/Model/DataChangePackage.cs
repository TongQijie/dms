using System.Xml.Serialization;

namespace Dade.Dms.Opc.Model
{
    [XmlRoot("dataChange")]
    public class DataChangePackage
    {
        [XmlAttribute("transactionId")]
        public int TransactionId { get; set; }

        [XmlElement("item")]
        public DataChangeItem[] Items { get; set; }
    }
}
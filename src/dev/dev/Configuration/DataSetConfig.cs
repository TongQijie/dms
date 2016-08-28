using System.Xml.Serialization;

namespace Dade.Dms.Dev.Configuration
{
    [XmlRoot("dataSet")]
    public class DataSetConfig
    {
        [XmlElement("row")]
        public DataRowConfig[] Rows { get; set; }
    }
}

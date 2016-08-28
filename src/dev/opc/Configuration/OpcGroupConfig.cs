using System.Xml.Serialization;

namespace Dade.Dms.Opc.Configuration
{
    public class OpcGroupConfig
    {
        public OpcGroupConfig()
        {
            UpdateRate = -1;
        }

        [XmlAttribute("enable")]
        public bool Enable { get; set; }

        [XmlAttribute("updateRate")]
        public int UpdateRate { get; set; }

        [XmlAttribute("isActive")]
        public bool IsActive { get; set; }

        [XmlAttribute("isSubscribed")]
        public bool IsSubscribed { get; set; }
    }
}

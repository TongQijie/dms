using System.Xml.Serialization;

namespace Dade.Dms.Opc.Configuration
{
    public class OpcGroupsConfig
    {
        public OpcGroupsConfig()
        {
            DefaultGroupDeadband = -1;
            DefaultGroupLocaleID = -1;
            DefaultGroupTimeBias = -1;
            DefaultGroupUpdateRate = -1;
        }

        [XmlAttribute("enable")]
        public bool Enable { get; set; }

        [XmlAttribute("defaultGroupDeadband")]
        public float DefaultGroupDeadband { get; set; }

        [XmlAttribute("defaultGroupIsActive")]
        public bool DefaultGroupIsActive { get; set; }

        [XmlAttribute("defaultGroupLocaleID")]
        public int DefaultGroupLocaleID { get; set; }

        [XmlAttribute("defaultGroupTimeBias")]
        public int DefaultGroupTimeBias { get; set; }

        [XmlAttribute("defaultGroupUpdateRate")]
        public int DefaultGroupUpdateRate { get; set; }
    }
}
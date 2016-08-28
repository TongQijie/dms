using System.Xml.Serialization;

namespace Dade.Dms.Opc.Configuration
{
    [XmlRoot("opcSettings")]
    public class OpcSettingsConfig
    {
        [XmlElement("opcGroups")]
        public OpcGroupsConfig[] GroupsSettings { get; set; }

        [XmlElement("opcGroup")]
        public OpcGroupConfig[] GroupSettings { get; set; }
    }
}

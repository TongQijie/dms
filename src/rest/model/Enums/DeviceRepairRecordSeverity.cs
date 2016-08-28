using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum DeviceRepairRecordSeverity
    {
        [EnumValue("N")]
        Normal,

        [EnumValue("S")]
        Severe,
    }
}

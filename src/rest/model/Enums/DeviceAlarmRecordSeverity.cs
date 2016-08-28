using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum DeviceAlarmRecordSeverity
    {
        [EnumValue("N")]
        Normal,

        [EnumValue("F")]
        Fault,
    }
}

using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum MaintenancePlanScheduleType
    {
        [EnumValue("C")]
        Custom,

        [EnumValue("D")]
        Daily,

        [EnumValue("W")]
        Weekly,

        [EnumValue("M")]
        Monthly,

        [EnumValue("Y")]
        Yearly,
    }
}

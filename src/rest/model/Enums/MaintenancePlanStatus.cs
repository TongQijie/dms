using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum MaintenancePlanStatus
    {
        [EnumValue("A")]
        Available,

        [EnumValue("S")]
        Suspend,

        [EnumValue("N")]
        Closed,
    }
}

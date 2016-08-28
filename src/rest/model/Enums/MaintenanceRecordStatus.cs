using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum MaintenanceRecordStatus
    {
        [EnumValue("P")]
        Pending,

        [EnumValue("O")]
        Ongoing,

        [EnumValue("D")]
        Done,

        [EnumValue("C")]
        Closed,
    }
}

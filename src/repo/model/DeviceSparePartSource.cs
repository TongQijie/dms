using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.RepoModel
{
    public class DeviceSparePartSource : FoundationInfoSource
    {
        [PlainDataMapping]
        public string SparePartNumber { get; set; }

        [PlainDataMapping]
        public string SparePartName { get; set; }

        [PlainDataMapping]
        public string Category { get; set; }

        [PlainDataMapping]
        public int ServiceLife { get; set; }

        [PlainDataMapping]
        public string Remark { get; set; }
    }
}

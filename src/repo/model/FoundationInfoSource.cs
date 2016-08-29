using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.DataModel
{
    public class FoundationInfoSource
    {
        [PlainDataMapping]
        public string CreationDate { get; set; }

        [PlainDataMapping]
        public string ModifiedDate { get; set; }
    }
}

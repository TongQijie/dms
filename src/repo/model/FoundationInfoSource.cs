using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.RepoModel
{
    public class FoundationInfoSource
    {
        [PlainDataMapping]
        public string CreationDate { get; set; }

        [PlainDataMapping]
        public string ModifiedDate { get; set; }
    }
}

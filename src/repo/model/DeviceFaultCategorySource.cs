using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.RepoModel
{
    public class DeviceFaultCategorySource
    {
        [PlainDataMapping]
        public int Id { get; set; }

        [PlainDataMapping]
        public string Title { get; set; }

        [PlainDataMapping]
        public string Description { get; set; }
    }
}

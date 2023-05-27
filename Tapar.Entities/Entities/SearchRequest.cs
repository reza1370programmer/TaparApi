

using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class SearchRequest : BaseEntity<Guid>
    {
        public string SearchKey { get; set; }
        public int SearchCount { get; set; } = 0;
        public DateTime SearchDate { get; set; } = DateTime.Now;
    }
}

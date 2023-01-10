

namespace Tapar.Core.Common.Dtos
{
    public class SearchParams
    {
        public string? searchKey { get; set; }
        public string? cat3Id { get; set; } = null;
        public int pageIndex { get; set; } = 1;
        public List<int>? filters { get; set; }
    }
    public class SearchParamsForUserPanel
    {
        public string? searchKey { get; set; }
        public int pageIndex { get; set; } = 1;
        public long userid { get; set; }
    }
}

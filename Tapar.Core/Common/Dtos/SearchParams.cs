

namespace Tapar.Core.Common.Dtos
{
    public class SearchParams
    {
        public string? searchKey { get; set; }
        public int pageIndex { get; set; } = 1;
        public int? cityId { get; set; }
    }
    public class SearchParamsForMobile
    {
        public string? searchKey { get; set; }
        public int? cityId { get; set; }
    }
    public class SearchParamsForUserPanel
    {
        public string? searchKey { get; set; }
        public int pageIndex { get; set; } = 1;
        public long userid { get; set; }
    }
}

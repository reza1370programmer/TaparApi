﻿

namespace Tapar.Core.Common.Dtos.Filters
{
 
    public class FilterDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string enTitle { get; set; }
        public List<ChildFilterDto>? childFilters { get; set; } = null;
    }
    public class ChildFilterDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string enTitle { get; set; }
    }

}

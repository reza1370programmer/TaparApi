

namespace Tapar.Core.Common.Dtos
{
    public class Categories
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<ChildCategories> cat3s { get; set; }
    }
    public class ChildCategories
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}



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
    public class CatDto
    {
        public int id { get; set; }
        public string name { get; set; }
    } 
    public class Cat2DtoForSuperAdmin
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool selected { get; set; } = false;
    }
}

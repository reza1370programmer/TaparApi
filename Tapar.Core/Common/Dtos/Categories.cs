

using System.ComponentModel.DataAnnotations;

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
    public class AddCat2Dto
    {
        [Required(ErrorMessage ="لطفا نام دسته را وارد کنید")]
        [StringLength(100,ErrorMessage ="تعداد کاراکترها نمیتواند بیشتر از 100 باشد")]
        public string name { get; set; }
        [Required(ErrorMessage ="لطفا دسته اول را مشخص کنید")]
        public int cat1Id { get; set; }
    }
    public class Cat2DtoForSuperAdmin
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool selected { get; set; } = false;
    }
}

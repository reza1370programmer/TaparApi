

using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

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
        public bool isSelected { get; set; } = false;
    }
    public class FilterAddDto
    {
        [Required(ErrorMessage ="لطفا نام فارسی فیلتر را وارد کنید")]
        [StringLength(50,ErrorMessage ="تعداد کاراکترها نمیتواند بیشتر از 50 باشد")]
        public string title { get; set; }
        [Required(ErrorMessage = "لطفا نام انگلیسی فیلتر را وارد کنید")]
        [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 باشد")]
        public string enTitle { get; set; }
    }
    public class FilterEditDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "لطفا نام فارسی فیلتر را وارد کنید")]
        [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 باشد")]
        public string title { get; set; }
        [Required(ErrorMessage = "لطفا نام انگلیسی فیلتر را وارد کنید")]
        [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 باشد")]
        public string enTitle { get; set; }
    }
    public class ChildFilterAddDto
    {
        [Required(ErrorMessage = "لطفا نام فارسی فیلتر را وارد کنید")]
        [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 باشد")]
        public string title { get; set; }
        [Required(ErrorMessage = "لطفا نام انگلیسی فیلتر را وارد کنید")]
        [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 باشد")]
        public string enTitle { get; set; }
        [Required(ErrorMessage = "لطفا نام دسته بندی دوم را وارد کنید")]
        public int parentId { get; set; }
    }
    public class ChildFilterEditDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "لطفا نام فارسی فیلتر را وارد کنید")]
        [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 باشد")]
        public string title { get; set; }
        [Required(ErrorMessage = "لطفا نام انگلیسی فیلتر را وارد کنید")]
        [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 باشد")]
        public string enTitle { get; set; }
        [Required(ErrorMessage = "لطفا نام دسته بندی دوم را وارد کنید")]
        public int parentId { get; set; }
    }
    public class AddFilterToCat2Dto
    {
        public int filterId { get; set; }
        public int cat2Id { get; set; }
    }
    public class DeleteFilterFromCat2Dto
    {
        public int filterId { get; set; }
        public int cat2Id { get; set; }
    }

}

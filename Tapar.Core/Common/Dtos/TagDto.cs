

using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos
{
    public class TagDto
    {
        [Required(ErrorMessage ="دسته بندی سطح سوم را انتخاب کیند")]
        public int cat3Id { get; set; }
        [Required(ErrorMessage = "عنوان تگ را وارد کنید")]
        [StringLength(20,ErrorMessage ="تعداد کاراکترها نمیتواند بیشتر از 20 تا باشد")]
        public string title { get; set; }
        public long id { get; set; }
    }
    public class AddTagDto
    {
        [Required(ErrorMessage = "عنوان تگ را وارد کنید")]
        [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 تا باشد")]
        public string title { get; set; }
        [Required(ErrorMessage = "دسته بندی سطح سوم را انتخاب کیند")]
        public int cat3Id { get; set; }
    }
    public class DeleteTagDto
    {
        [Required(ErrorMessage ="لطفا تگ مورد نظر را انتخاب کنید")]
        public long tagid { get; set; }
        [Required(ErrorMessage = "دسته بندی سطح سوم را انتخاب کیند")]
        public int cat3id { get; set; }
    }
    public class UpdateUserTagsDto {
        [Required]
        public long placeid { get; set; }
        [Required]
        [StringLength(1000)]
        public string tags { get; set; }
    }
}

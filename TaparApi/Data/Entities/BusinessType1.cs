using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class BusinessType1:BaseEntity<long>
{
    [Required(ErrorMessage = "لطفا نام دسته بندی را وارد کنید")]
    [MaxLength(100, ErrorMessage = "تعداد کاراکترهای فیلد نمیتواند بیشتر از 100 باشد")]
    public string name { get; set; }
    [Required(ErrorMessage = "لطفا توضیحات دسته بندی را وارد کنید")]
    [MaxLength(1000, ErrorMessage = "تعداد کاراکترهای فیلد نمیتواند بیشتر از 1000 باشد")]
    public string gdesc { get; set; }

    [ForeignKey(nameof(BusinessCategory))]
    [Required]
    public long businessCategoryId { get; set; }
    public BusinessCategory BusinessCategory { get; set; }
    public List<BusinessType2> BusinessType2s { get; set; }
    public List<SpecialTypeField> SpecialTypeFields { get; set; }
}
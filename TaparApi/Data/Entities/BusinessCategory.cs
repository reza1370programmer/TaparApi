using System.ComponentModel.DataAnnotations;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class BusinessCategory:BaseEntity<long>
{
    [Required(ErrorMessage = "لطفا نام دسته بندی را وارد کنید")]
    [MaxLength(100,ErrorMessage = "تعداد کاراکترهای فیلد نمیتواند بیشتر از 100 باشد")]
    public string name { get; set; }
    [Required(ErrorMessage = "لطفا توضیحات دسته بندی را وارد کنید")]
    [MaxLength(1000, ErrorMessage = "تعداد کاراکترهای فیلد نمیتواند بیشتر از 1000 باشد")]
    public string gdesc { get; set; }
    public DateTime? approvedDate { get; set; }
    public DateTime? deactivatedDate { get; set; }
    public DateTime? deletedDate { get; set; }

    public List<BusinessType1> BusinessType1s { get; set; }
}
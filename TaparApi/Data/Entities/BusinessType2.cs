using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class BusinessType2:BaseEntity<long>
{
    [Required(ErrorMessage = "لطفا نام دسته بندی را وارد کنید")]
    [MaxLength(100, ErrorMessage = "تعداد کاراکترهای فیلد نمیتواند بیشتر از 100 باشد")]
    public string name { get; set; }
    [Required(ErrorMessage = "لطفا توضیحات دسته بندی را وارد کنید")]
    [MaxLength(1000, ErrorMessage = "تعداد کاراکترهای فیلد نمیتواند بیشتر از 1000 باشد")]
    public string gdesc { get; set; }

    public DateTime? approvedDate { get; set; }
    public DateTime? deactivatedDate { get; set; }
    public DateTime? deletedDate { get; set; }

    [ForeignKey(nameof(BusinessType1))]
    [Required]
    public long businessType1Id { get; set; }
    public BusinessType1 BusinessType1 { get; set; }
    public List<SpecialTypeField> SpecialTypeFields { get; set; }
}
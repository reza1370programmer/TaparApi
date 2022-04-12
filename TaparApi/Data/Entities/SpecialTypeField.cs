using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class SpecialTypeField : BaseEntity<long>
{
    [Required(ErrorMessage = "لطفا عنوان فیلد را وارد کنید")]
    [MaxLength(50, ErrorMessage = "تعداد کاراکترهای فیلد نمیتواند بیشتر از 50 باشد")]
    public string title { get; set; }
    [Required(ErrorMessage = "لطفا عنوان انگلیسی فیلد را وارد کنید")]
    [MaxLength(50, ErrorMessage = "تعداد کاراکترهای فیلد نمیتواند بیشتر از 50 باشد")]
    public string enTitle { get; set; }
    [MaxLength(20)]
    public string? minLength { get; set; }
    [MaxLength(20)]
    public string? maxLength { get; set; }
    [MaxLength(50)]
    public string? regex { get; set; }
    [MaxLength(200)]
    public string?  multiSelect { get; set; }
    [ForeignKey(nameof(BusinessType1))]
    public long? businessType1Id { get; set; }
    public BusinessType1 BusinessType1 { get; set; }
    [ForeignKey(nameof(BusinessType2))]
    public long? businessType2Id { get; set; }
    public BusinessType2 BusinessType2 { get; set; }
    [Required]
    [ForeignKey(nameof(FieldType))]
    public int fieldTypeId { get; set; }
    public FieldType FieldType { get; set; }
}
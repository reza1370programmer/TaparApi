using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.DynamicFields;

public class DynamicFieldsAddDto
{
    [Required(ErrorMessage = "لطفا نام فیلد پویا را وارد کنید")]
    public string title { get; set; }
    [Required(ErrorMessage = "لطفا نام انگلیسی فیلد پویا را وارد کنید")]
    public string enTitle { get; set; }
    public string? minLength { get; set; }
    public string? maxLength { get; set; }
    public string? regex { get; set; }
    public string? multiSelect { get; set; }
    public long? businessType1Id { get; set; }
    public long? businessType2Id { get; set; }
    [Required(ErrorMessage = "لطفا نوع فیلد پویا را انتخاب کنید")]
    public int fieldTypeId { get; set; }

}
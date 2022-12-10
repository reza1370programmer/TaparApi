using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.DynamicFields;

public class DynamicFieldsAddDto
{
    [Required(ErrorMessage = "لطفا نام فیلد پویا را وارد کنید")]
    [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 تا باشد")]
    public string title { get; set; }
    [Required(ErrorMessage = "لطفا نام انگلیسی فیلد پویا را وارد کنید")]
    [StringLength(50, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 50 تا باشد")]
    public string enTitle { get; set; }
    [Required(ErrorMessage = "لطفا طول رشته را وارد کنید")]
    [StringLength(5, ErrorMessage = "تعداد کاراکترها نمیتواند بیشتر از 5 تا باشد")]
    public string maxLength { get; set; }
    [Required(ErrorMessage = "اجباری یا اختیاری بودن فیلد را مشخص کنید")]
    public bool isRequired { get; set; }
    [Required(ErrorMessage = "دسته بندی دوم را مشخص کنید")]
    public int cat2Id { get; set; }

}
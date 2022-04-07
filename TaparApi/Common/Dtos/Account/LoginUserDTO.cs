using System.ComponentModel.DataAnnotations;

namespace TaparApi.Common.Dtos.Account
{
    public class LoginSuperAdminDTO
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string userName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string password { get; set; }
    }

    public enum LoginUserResult
    {
        Success,
        IncorrectData,
        NotActivated
    }
}

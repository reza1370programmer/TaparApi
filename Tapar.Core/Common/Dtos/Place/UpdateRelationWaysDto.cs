

using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.Place
{
    public class UpdateRelationWaysDto
    {
        public long id { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکترهای تلفن1 نمیتواند از 20 بیشتر باشد")]
        public string? phone1 { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکترهای تلفن2 نمیتواند از 20 بیشتر باشد")]
        public string? phone2 { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکترهای تلفن3 نمیتواند از 20 بیشتر باشد")]
        public string? phone3 { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکترهای موبایل1 نمیتواند از 20 بیشتر باشد")]
        public string? mob1 { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکترهای موبایل2 نمیتواند از 20 بیشتر باشد")]
        public string? mob2 { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکترهای فاکس نمیتواند از 20 بیشتر باشد")]
        public string? fax { get; set; }
        [MaxLength(50, ErrorMessage = "تعداد کاراکترهای ایمیل نمیتواند از 50 بیشتر باشد")]
        public string? email { get; set; }
        [MaxLength(50, ErrorMessage = "تعداد کاراکترهای وبسایت نمیتواند از 50 بیشتر باشد")]
        public string? website { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکترهای تلگرام نمیتواند از 20 بیشتر باشد")]
        public string? telegram { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکترهای اینستاگرام نمیتواند از 20 بیشتر باشد")]
        public string? instagram { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکترهای واتساپ نمیتواند از 20 بیشتر باشد")]
        public string? whatsapp { get; set; }
    }
}

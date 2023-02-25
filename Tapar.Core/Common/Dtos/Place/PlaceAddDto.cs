
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.Place
{
    public class PlaceAddDto
    {
        [Required(ErrorMessage = "نام تابلو را وارد کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکترهای تابلو نمیتواند از 500 بیشتر باشد")]
        public string tablo { get; set; }
        [MaxLength(200, ErrorMessage = "تعداد کاراکترهای توضیحات نمیتواند از 200 بیشتر باشد")]
        public string? description { get; set; }
        [Required(ErrorMessage = "نام مدیر را وارد کنید")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکترهای مدیر نمیتواند از 50 بیشتر باشد")]
        public string modir { get; set; }
        public Address address { get; set; }
        public RelationWays relationWays { get; set; }
        [Required(ErrorMessage = "آیدی زمان کاری را وارد کنید")]
        public int workingTimeId { get; set; }
        public List<WorkingDays>? workingDays { get; set; }
        public List<IFormFile>? businessPics { get; set; }
        public List<IFormFile>? modirPic { get; set; }
        public List<IFormFile>? visitCartPics { get; set; }
    }
    public class Address
    {
        [Required(ErrorMessage = "استان مورد نظر خود را وارد کنید")]
        public string ostan { get; set; }
        [Required(ErrorMessage = "شهرستان مورد نظر خود را وارد کنید")]
        public string shahrestan { get; set; }
        [MaxLength(500, ErrorMessage = "تعداد کاراکترهای آدرس نمیتواند از 500 بیشتر باشد")]
        public string? restAddress { get; set; }
    }
    public class RelationWays
    {
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
    public class WorkingDays
    {
        public int? id { get; set; }
        public bool am { get; set; } = false;
        public bool pm { get; set; } = false;
    }
}

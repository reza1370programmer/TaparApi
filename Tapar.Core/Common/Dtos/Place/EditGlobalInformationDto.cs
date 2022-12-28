

using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.Place
{
    public class EditGlobalInformationDto
    {
        [Required]
        public long id { get; set; }
        [Required, MaxLength(500)]
        public string tablo { get; set; }
        [Required, MaxLength(50)]
        public string manager { get; set; }
        [MaxLength(200)]
        public string service_description { get; set; }
    }
}

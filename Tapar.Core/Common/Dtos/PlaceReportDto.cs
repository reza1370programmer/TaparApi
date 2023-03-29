

using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos
{
    public class AddReportForPlaceDto
    {
        [Required]
        public int ReportOptionId { get; set; }
        [Required]
        public long PlaceId { get; set; }
        [MaxLength(200)]
        public string Other_Description { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.Place
{
    public class UpdateWorkTimeDto
    {
        [Required]
        public long PlaceId { get; set; }
        [Required]
        public int WorkTimeId { get; set; }
        public List<WorkingDays>? WorkingDays { get; set; }
    }
}

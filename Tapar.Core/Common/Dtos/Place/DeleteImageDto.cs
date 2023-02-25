

using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.Place
{
    public class DeleteImageDto
    {
        [Required]
        public long PlaceId { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public string FieldName { get; set; }
    }
}

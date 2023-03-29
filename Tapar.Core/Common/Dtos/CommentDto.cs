

using System.ComponentModel.DataAnnotations;
using Tapar.Data.Entities;

namespace Tapar.Core.Common.Dtos
{
    public class AddCommentDto
    {
        [Required]
        public long PlaceId { get; set; }
        [Required]
        [StringLength(500)]
        public string Text { get; set; }
    }
 
}

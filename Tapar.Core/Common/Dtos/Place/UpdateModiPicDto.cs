

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.Place
{
    public class UpdateModiPicDto
    {
        [Required]
        public long placeid { get; set; }
        public IFormFile? modirpic { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.Place
{
    public class PlacePicUpdateDto
    {
        [Required]
        public long placeid { get; set; }
        public IFormFile? businessPic1 { get; set; } 
        public IFormFile? businessPic2 { get; set; } 
        public IFormFile? businessPic3 { get; set; }
    }
}

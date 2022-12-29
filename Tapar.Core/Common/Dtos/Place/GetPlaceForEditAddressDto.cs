

using System.ComponentModel.DataAnnotations;

namespace Tapar.Core.Common.Dtos.Place
{
    public class GetPlaceForEditAddressDto
    {
        public int ParentLocationId { get; set; }
        public int ChildLocationId { get; set; }
        public string RestAddress { get; set; }
    }
    public class EditAddressDto
    {
        [Required]
        public long placeid { get; set; }
        [Required]
        public int locationId { get; set; }
        [Required]
        [MaxLength(500)]
        public string restAddress { get; set; }
    }

}

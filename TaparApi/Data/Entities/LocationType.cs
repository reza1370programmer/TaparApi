using System.ComponentModel.DataAnnotations;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class LocationType:BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string name { get; set; }

    public List<Location> Locations { get; set; }
}
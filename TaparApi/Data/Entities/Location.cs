using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class Location : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string name { get; set; }
    [Required]
    [MaxLength(50)]
    public string longitude { get; set; }
    [Required]
    [MaxLength(50)]
    public string latitude { get; set; }
    public int? parentId { get; set; }
    [ForeignKey(nameof(LocationType))]
    public int locationTypeId { get; set; }
    public LocationType LocationType { get; set; }
    public List<BusinessOffice> BusinessOffices { get; set; }
}
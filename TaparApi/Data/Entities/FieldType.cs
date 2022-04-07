using System.ComponentModel.DataAnnotations;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class FieldType:BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string name { get; set; }    
}
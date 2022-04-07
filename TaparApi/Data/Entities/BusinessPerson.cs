using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class BusinessPerson : SharedEntity
{
    [Required]
    [MaxLength(20)]
    public string firstName { get; set; }
    [Required]
    [MaxLength(20)]
    public string lastName { get; set; }
    [Required]
    [MaxLength(5)]
    public string gender { get; set; }
    [MaxLength(200)]
    public string gDesc { get; set; }
    [MaxLength(15)]
    public string nationalCode { get; set; }
    [MaxLength(200)]
    public string pic { get; set; }

    [ForeignKey(nameof(User))]
    public long userId { get; set; }
    public User User { get; set; }
}
using System.ComponentModel.DataAnnotations;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class User : BaseEntity<long>
{
    [Required]
    [StringLength(20)]
    public string userName { get; set; }
    [StringLength(20)]
    public string password { get; set; }
    [StringLength(15)]
    [Required]
    public string? mobile { get; set; }
    [StringLength(50)]
    public string? email { get; set; }
    [StringLength(20)]
    public string? nickName { get; set; }
    [StringLength(20)]
    public string? firstName { get; set; }
    [StringLength(20)]
    public string? lastName { get; set; }
    [StringLength(20)]
    public string? nationalCode { get; set; }

    public List<BusinessOffice>? BusinessOffices { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<ViewCount>? ViewCounts { get; set; }
    public List<LikeCount>? LikeCounts { get; set; }

}
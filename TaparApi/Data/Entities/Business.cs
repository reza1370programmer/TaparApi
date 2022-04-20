using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class Business:SharedEntity
{
    [MaxLength(100)]
    [Required]
    public string titel { get; set; }
    [MaxLength(500)]
    [Required]
    public string serviceDesc { get; set; }
    [MaxLength(15)]
    public string phone { get; set; }
    public int? likeCount { get; set; }
    public int? viewCount { get; set; }
    [StringLength(200)]
    public string workTimeDesc { get; set; }
    [StringLength(200)]
    public string specialMessage { get; set; }
    [StringLength(15)]
    public string longitude { get; set; }
    [StringLength(15)]
    public string lattitude { get; set; }
    [StringLength(500)]
    public string address { get; set; } = null!;
    [StringLength(20)]
    public string visitPic { get; set; }
    [StringLength(20)]
    public string tabloPic { get; set; }
    [StringLength(500)]
    public string workTime { get; set; }

    #region BusinessPerson
    [StringLength(20)]
    public string firstName { get; set; }
    [StringLength(20)]
    public string lastName { get; set; }
    [StringLength(20)]
    public string gender { get; set; }
    [StringLength(100)]
    public string gdesc { get; set; }
    [StringLength(15)]
    public string nationalCode { get; set; }
    [StringLength(100)]
    public string picture { get; set; }

    #endregion

    [ForeignKey(nameof(BusinessOffice))]
    public long businessOfficeId { get; set; }
    public BusinessOffice BusinessOffice { get; set; }
    [ForeignKey(nameof(BusinessType2))]
    public long businessType2Id { get; set; }
    public BusinessType2 BusinessType2 { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<ViewCount>? ViewCounts { get; set; }
    public List<LikeCount>? LikeCounts { get; set; }
    public List<BusinessUpdate> BusinessUpdates { get; set; }
}
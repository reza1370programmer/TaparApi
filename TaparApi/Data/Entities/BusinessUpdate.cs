using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class BusinessUpdate : BaseEntity<long>
{
    [MaxLength(100)]
    public string titel { get; set; }
    [MaxLength(500)]
    public string serviceDesc { get; set; }
    [MaxLength(15)]
    public string phone { get; set; }
    [StringLength(200)]
    public string workTimeDesc { get; set; }
    [StringLength(200)]
    public string specialMessage { get; set; }
    [StringLength(15)]
    public string longitude { get; set; }
    [StringLength(15)]
    public string lattitude { get; set; }
    [StringLength(500)]
    public string address { get; set; }
    [StringLength(50)]
    public string visitPic { get; set; }
    [StringLength(50)]
    public string tabloPic { get; set; }
    [StringLength(50)]
    public string? picture { get; set; }
    [StringLength(20)]
    public string? firstName { get; set; }
    [StringLength(20)]
    public string? lastName { get; set; }
    [StringLength(20)]
    public string? gender { get; set; }
    [StringLength(100)]
    public string? gdesc { get; set; }
    [StringLength(15)]
    public string? nationalCode { get; set; }
    [StringLength(500)]
    public string workTime { get; set; }
    public DateTime? modifiedDate { get; set; }
    public long? modifiedUserId { get; set; }
    [ForeignKey(nameof(Business))]
    public long businessId { get; set; }
    public Business Business { get; set; }
}
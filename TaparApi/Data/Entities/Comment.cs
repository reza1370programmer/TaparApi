using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class Comment:BaseEntity<long>
{
    public string body { get; set; }
    public DateTime createDate { get; set; }
    public DateTime approvedDate { get; set; }
    public long approveUserId { get; set; }
    [ForeignKey(nameof(user))]
    public long? userId { get; set; }
    public User user { get; set; }
    [ForeignKey(nameof(Business))]
    public long? businessId { get; set; }
    public Business Business { get; set; }
}
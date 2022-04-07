using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class ViewCount:BaseEntity<long>
{
    public DateTime viewDate { get; set; }
    public string clientDetail { get; set; }
    [ForeignKey(nameof(User))]
    public long userId { get; set; }
    public User User { get; set; }
    [ForeignKey(nameof(Business))]
    public long businessId { get; set; }
    public Business Business { get; set; }
}
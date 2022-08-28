using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace TaparApi.Data.Entities;

public class LikeCount:BaseEntity<long>
{
    public DateTime? likeDate { get; set; }
    public long userId { get; set; }
    public User User { get; set; } 
    public long businessId { get; set; }
}
public class LikeCountConfiguration : IEntityTypeConfiguration<LikeCount>
{
    public void Configure(EntityTypeBuilder<LikeCount> builder)
    {
        builder.Property(p => p.likeDate).IsRequired(false);
        builder.HasOne(p => p.User).WithMany(p => p.LikeCounts).HasForeignKey(p => p.userId).IsRequired();
    }
}
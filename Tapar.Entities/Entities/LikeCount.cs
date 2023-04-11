using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class LikeCount : BaseEntity
{
    public DateTime? likeDate { get; set; }
    public long userId { get; set; }
    public User User { get; set; }
    public long placeId { get; set; }
    public Place place { get; set; }
}
public class LikeCountConfiguration : IEntityTypeConfiguration<LikeCount>
{
    public void Configure(EntityTypeBuilder<LikeCount> builder)
    {
        builder.Property(p => p.likeDate).IsRequired(false);
        builder.HasOne(p => p.User).WithMany(p => p.LikeCounts).HasForeignKey(p => p.userId).IsRequired();
        builder.HasOne(p => p.place).WithMany(p => p.likeCounts).HasForeignKey(p => p.placeId).IsRequired();
    }
}
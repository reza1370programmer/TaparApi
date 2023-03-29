using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class Comment : BaseEntity<int>
{
    public string text { get; set; }
    public DateTime create_date { get; set; }
    public long userId { get; set; }
    public User user { get; set; }
    public long placeId { get; set; }
    public Place place { get; set; }
    public bool status { get; set; } = false;
}
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(p => p.text).HasMaxLength(500).IsRequired(true);
        builder.Property(p => p.userId).IsRequired(true);
        builder.Property(p => p.create_date).IsRequired(true);
        builder.Property(p => p.placeId).IsRequired(true);
        builder.HasOne(p => p.user).WithMany(p => p.Comments).HasForeignKey(p => p.userId).IsRequired(true);
        builder.HasOne(p => p.place).WithMany(p => p.comments).HasForeignKey(p => p.placeId).IsRequired(true);
    }
}
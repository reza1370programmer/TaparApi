using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;
using Tapar.Data.Entities;

namespace TaparApi.Data.Entities;

public class Comment:BaseEntity<int>
{
    public string text { get; set; }
    public string create_date { get; set; }
    public string approv_date { get; set; }
    public long  approv_date_userId { get; set; }
    public long userId { get; set; }
    public User user { get; set; }
    public long placeId { get; set; }
    public Place place { get; set; }
}
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(p => p.text).HasMaxLength(500).IsRequired(true);
        builder.Property(p => p.create_date).HasMaxLength(20).IsRequired(true);
        builder.Property(p => p.approv_date).HasMaxLength(20).IsRequired(true);
        builder.HasOne(p => p.user).WithMany(p => p.Comments).HasForeignKey(p => p.userId).IsRequired(true);
        builder.HasOne(p => p.place).WithMany(p => p.comments).HasForeignKey(p => p.placeId).IsRequired(true);
    }
}
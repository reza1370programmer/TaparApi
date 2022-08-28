using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace TaparApi.Data.Entities;

public class Comment:SharedEntity
{
    public string body { get; set; }
    public long userId { get; set; }
    public User user { get; set; }
    public long businessId { get; set; }
}
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(p => p.body).HasMaxLength(500).IsRequired(false);
        builder.HasOne(p => p.user).WithMany(p => p.Comments).HasForeignKey(p => p.userId).IsRequired(true);
    }
}
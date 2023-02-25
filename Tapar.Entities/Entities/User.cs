using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class User : BaseEntity<long>
{
    public string Password { get; set; }
    public string Mobile { get; set; }
    public string? FullName { get; set; }
    public List<Place>? places { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<LikeCount>? LikeCounts { get; set; }
    public List<RefreshTokens>? refreshTokens { get; set; }
    public List<Place_Report> PlaceReport { get; set; }
}
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.Password).HasMaxLength(20).IsRequired(true);
        builder.Property(p => p.Mobile).HasMaxLength(11).IsRequired(true);
        builder.Property(p => p.FullName).HasMaxLength(15).IsRequired(false);
    }
}
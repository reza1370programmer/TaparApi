using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;
using Tapar.Data.Entities;

namespace TaparApi.Data.Entities;

public class User : BaseEntity<long>
{
    public string? userName { get; set; }
    public string? password { get; set; }
    public string mobile { get; set; }
    public string? email { get; set; }
    public string? nickName { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public List<Place>? places { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<ViewCount>? ViewCounts { get; set; }
    public List<LikeCount>? LikeCounts { get; set; }
    public List<RefreshTokens>? refreshTokens { get; set; }
}
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.userName).HasMaxLength(20).IsRequired(false);
        builder.Property(p => p.password).HasMaxLength(20).IsRequired(false);
        builder.Property(p => p.mobile).HasMaxLength(11).IsRequired(true);
        builder.Property(p => p.email).HasMaxLength(50).IsRequired(false);
        builder.Property(p => p.nickName).HasMaxLength(20).IsRequired(false);
        builder.Property(p => p.firstName).HasMaxLength(20).IsRequired(false);
        builder.Property(p => p.lastName).HasMaxLength(20).IsRequired(false);
    }
}
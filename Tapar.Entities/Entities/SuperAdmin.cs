using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class SuperAdmin : BaseEntity
{
    public string userName { get; set; }
    public string password { get; set; }
    public string fullName { get; set; }
    public int adminType { get; set; } = 1;
    public List<RefreshTokens>? refreshTokens { get; set; }
}
public class SuperAdminConfiguration : IEntityTypeConfiguration<SuperAdmin>
{
    public void Configure(EntityTypeBuilder<SuperAdmin> builder)
    {
        builder.Property(p => p.userName).HasMaxLength(30).IsRequired(true);
        builder.Property(p => p.password).HasMaxLength(30).IsRequired(true);
        builder.Property(p => p.fullName).HasMaxLength(30).IsRequired(true);
        builder.Property(p => p.adminType).IsRequired(true);
    }
}
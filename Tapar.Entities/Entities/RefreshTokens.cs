using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace TaparApi.Data.Entities
{
    public class RefreshTokens:BaseEntity<long>
    {
        public DateTime? expirationDate { get; set; }
        public string? refreshToken { get; set; }
        public long? userId { get; set; }     
        public int? superAdminId { get; set; }
        public User user { get; set; }
        public SuperAdmin superAdmin { get; set; }
    }
    public class RefreshTokensConfiguration : IEntityTypeConfiguration<RefreshTokens>
    {
        public void Configure(EntityTypeBuilder<RefreshTokens> builder)
        {
            builder.Property(p => p.expirationDate).IsRequired(false);
            builder.Property(p => p.refreshToken).IsRequired(false);
            builder.HasOne(p => p.user).WithMany(p => p.refreshTokens).HasForeignKey(p => p.userId).IsRequired(false);
            builder.HasOne(p => p.superAdmin).WithMany(p => p.refreshTokens).HasForeignKey(p => p.superAdminId).IsRequired(false);
        }
    }
}

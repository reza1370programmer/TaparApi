

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class UserAgent : BaseEntity<Guid>
    {
        public string Referer { get; set; }
        public DateTime EnteranceDate { get; set; } = DateTime.Now;
        public string BrowserName { get; set; }
        public string DeviceType { get; set; }
    }
    public class UserAgentConfiguration : IEntityTypeConfiguration<UserAgent>
    {
        public void Configure(EntityTypeBuilder<UserAgent> builder)
        {
            builder.Property(p => p.Referer).HasMaxLength(200).IsRequired();
            builder.Property(p => p.BrowserName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.DeviceType).HasMaxLength(200).IsRequired();
        }
    }
}

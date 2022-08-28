using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace TaparApi.Data.Entities;

public class ViewCount:BaseEntity<long>
{
    public DateTime? viewDate { get; set; }
    public string clientDetail { get; set; }
    public long userId { get; set; }
    public User User { get; set; }
}
public class ViewCountConfiguration : IEntityTypeConfiguration<ViewCount>
{
    public void Configure(EntityTypeBuilder<ViewCount> builder)
    {
        builder.Property(p => p.viewDate).IsRequired(false);
        builder.Property(p => p.clientDetail).HasMaxLength(1000).IsRequired(false);
        builder.HasOne(p => p.User).WithMany(p => p.ViewCounts).HasForeignKey(p => p.userId).IsRequired(false);
    }
}
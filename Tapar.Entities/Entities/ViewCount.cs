using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;
using Tapar.Data.Entities;

namespace Tapar.Data.Entities;

public class ViewCount:BaseEntity<long>
{
    public DateTime? viewDate { get; set; }
    public string clientDetail { get; set; }
    public long? userId { get; set; }
    public User User { get; set; }
    public long placeId { get; set; }
    public Place place { get; set; }
}
public class ViewCountConfiguration : IEntityTypeConfiguration<ViewCount>
{
    public void Configure(EntityTypeBuilder<ViewCount> builder)
    {
        builder.Property(p => p.viewDate).IsRequired(false);
        builder.Property(p => p.clientDetail).HasMaxLength(1000).IsRequired(false);
        builder.HasOne(p => p.User).WithMany(p => p.ViewCounts).HasForeignKey(p => p.userId).IsRequired(false);
        builder.HasOne(p => p.place).WithMany(p => p.viewCounts).HasForeignKey(p => p.placeId).IsRequired(true);
    }
}
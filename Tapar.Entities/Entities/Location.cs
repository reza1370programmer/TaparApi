using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class Location : BaseEntity
{
    public string name { get; set; }
    public string abbreviation { get; set; }
    public string longitude { get; set; }
    public string latitude { get; set; }
    public int? parentId { get; set; }
    public bool isActive { get; set; } = false;
    public List<Place> places { get; set; }
}
public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasIndex(x => x.abbreviation).IsUnique();
        builder.Property(p => p.name).HasMaxLength(50).IsRequired();
        builder.Property(p => p.abbreviation).HasMaxLength(10).IsRequired();
        builder.Property(p => p.longitude).HasMaxLength(50).IsRequired(false);
        builder.Property(p => p.latitude).HasMaxLength(50).IsRequired(false);
        builder.Property(p => p.parentId).IsRequired(false);
    }
}
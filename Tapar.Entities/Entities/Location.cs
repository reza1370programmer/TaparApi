using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class Location : BaseEntity
{
    public string name { get; set; }
    public string longitude { get; set; }
    public string latitude { get; set; }
    public int? parentId { get; set; }
    public List<Place> places { get; set; }
}
public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(p => p.name).HasMaxLength(50).IsRequired();
        builder.Property(p => p.longitude).HasMaxLength(50).IsRequired(false);
        builder.Property(p => p.latitude).HasMaxLength(50).IsRequired(false);
        builder.Property(p => p.parentId).IsRequired(false);
    }
}
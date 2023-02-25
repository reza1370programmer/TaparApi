using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class Location : BaseEntity
{
    public string name { get; set; }
    public int? parentId { get; set; }
    public bool isActive { get; set; } = false;
    public List<Place> places { get; set; }
}
public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {

        builder.Property(p => p.name).HasMaxLength(50).IsRequired();
        builder.Property(p => p.parentId).IsRequired(false);
        builder.HasData(
            new Location() { Id = 1, isActive = true, name = "آذربایجان شرقی", parentId = null },
            new Location() { Id = 2, isActive = true, name = "بناب", parentId = 1 }
           );
    }
}
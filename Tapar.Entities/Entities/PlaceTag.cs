

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class PlaceTag : BaseEntity<long>
    {
        public long PlaceId { get; set; }
        public long TagId { get; set; }
        public Place Place { get; set; }
        public Tag Tag { get; set; }
    }
    public class PlaceTagConfiguration : IEntityTypeConfiguration<PlaceTag>
    {
        public void Configure(EntityTypeBuilder<PlaceTag> builder)
        {
            builder.Property(p => p.PlaceId).IsRequired();
            builder.Property(p => p.TagId).IsRequired();
            builder.HasOne(p => p.Tag).WithMany(p => p.PlaceTags).HasForeignKey(p => p.TagId).IsRequired();
            builder.HasOne(p => p.Place).WithMany(p => p.PlaceTags).HasForeignKey(p => p.PlaceId).IsRequired();
        }
    }
}

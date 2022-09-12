
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Place_Tag:BaseEntity<long>
    {
        public long placeId { get; set; }
        public long tagId { get; set; }
        public Place place { get; set; }
        public Tag tag { get; set; }
    }
    public class Place_TagConfiguration : IEntityTypeConfiguration<Place_Tag>
    {
        public void Configure(EntityTypeBuilder<Place_Tag> builder)
        {
            builder.Property(p => p.tagId).IsRequired();
            builder.Property(p => p.placeId).IsRequired();
            builder.HasOne(p => p.place).WithMany(p => p.place_Tags).HasForeignKey(p => p.placeId).IsRequired();
            builder.HasOne(p => p.tag).WithMany(p => p.place_Tags).HasForeignKey(p => p.tagId).IsRequired();
        }
    }
}

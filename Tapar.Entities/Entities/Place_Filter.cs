using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Place_Filter:BaseEntity
    {
        public long placeId { get; set; }
        public Place place { get; set; }
        public int filters_Cat2Id { get; set; }
        public Filters_Cat2 Filters_Cat2 { get; set; }
    }
    public class Place_FilterConfiguration : IEntityTypeConfiguration<Place_Filter>
    {
        public void Configure(EntityTypeBuilder<Place_Filter> builder)
        {
            builder.HasOne(p => p.place).WithMany(p => p.place_Filters).HasForeignKey(p => p.placeId).IsRequired();
            builder.HasOne(p => p.Filters_Cat2).WithMany(p => p.place_Filters).HasForeignKey(p => p.filters_Cat2Id).IsRequired();
        }
    }
}

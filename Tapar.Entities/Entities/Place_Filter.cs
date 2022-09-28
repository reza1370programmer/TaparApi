using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Place_Filter:BaseEntity
    {
        public long placeId { get; set; }
        public Place place { get; set; }
        public int filterId { get; set; }
        public Filters filter { get; set; }
    }
    public class Place_FilterConfiguration : IEntityTypeConfiguration<Place_Filter>
    {
        public void Configure(EntityTypeBuilder<Place_Filter> builder)
        {
            builder.HasOne(p => p.place).WithMany(p => p.place_Filters).HasForeignKey(p => p.placeId).IsRequired();
            builder.HasOne(p => p.filter).WithMany(p => p.Place_Filters).HasForeignKey(p => p.filterId).IsRequired();
        }
    }
}

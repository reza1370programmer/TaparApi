using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class SubPlace : BaseEntity<long>
    {
        public string semat { get; set; }
        public string? description { get; set; }
        public string? internalPhone { get; set; }
        public string? personalPic { get; set; }
        public long? placeId { get; set; }
        public Place? place { get; set; }
    }
    public class SubPlaceConfiguraion : IEntityTypeConfiguration<SubPlace>
    {
        public void Configure(EntityTypeBuilder<SubPlace> builder)
        {
            builder.Property(p => p.semat).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.description).HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.internalPhone).HasMaxLength(11).IsRequired(false);
            builder.Property(p => p.placeId).IsRequired(false);
            builder.HasOne(p => p.place).WithMany(p => p.subPlaces).HasForeignKey(p => p.placeId);
        }
    }
}

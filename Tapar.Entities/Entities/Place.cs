using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;
using TaparApi.Data.Entities;

namespace Tapar.Data.Entities
{
    public class Place:BaseEntity<long>
    {
        public long userId { get; set; }
        public User  user { get; set; }
        public List<SubPlace> subPlaces { get; set; }
        public List<Comment> comments { get; set; }
        public List<ViewCount> viewCounts { get; set; }
        public List<LikeCount> likeCounts { get; set; }
        public List<Place_Filter> place_Filters { get; set; }
    }
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasOne(p => p.user).WithMany(p => p.places).HasForeignKey(p => p.userId);
        }
    }
}

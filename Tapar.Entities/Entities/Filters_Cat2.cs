using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Filters_Cat2:BaseEntity<long>
    {
        public int filterId { get; set; }
        public Filters filter { get; set; }
        public int cat2Id { get; set; }
        public Cat2 cat2 { get; set; }
      
    }
    public class Filters_Cat2Configuration : IEntityTypeConfiguration<Filters_Cat2>
    {
        public void Configure(EntityTypeBuilder<Filters_Cat2> builder)
        {
            builder.HasOne(p => p.cat2).WithMany(p => p.filters_Cat2s).HasForeignKey(p => p.cat2Id).IsRequired(true);
            builder.HasOne(p => p.filter).WithMany(p => p.filters_Cat2s).HasForeignKey(p => p.filterId).IsRequired(true);
        }
    }
}

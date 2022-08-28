using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;
using TaparApi.Data.Entities;

namespace Tapar.Data.Entities
{
    public class Filters_Cat2:BaseEntity
    {
        public string title { get; set; }
        public int? parentId { get; set; }
        public int? cat2Id { get; set; }
        public Cat2? cat2 { get; set; }
        public List<Place_Filter> place_Filters { get; set; }
    }
    public class Filters_Cat2Configuration : IEntityTypeConfiguration<Filters_Cat2>
    {
        public void Configure(EntityTypeBuilder<Filters_Cat2> builder)
        {
            builder.Property(p => p.title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.parentId).IsRequired(false);
            builder.HasOne(p => p.cat2).WithMany(p => p.filters_Cat2s).HasForeignKey(p => p.cat2Id).IsRequired(false);
        }
    }
}

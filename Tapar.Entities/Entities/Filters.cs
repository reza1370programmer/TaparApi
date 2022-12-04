using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Filters : BaseEntity
    {
        public string title { get; set; }
        public string enTitle { get; set; }
        public int? parentId { get; set; }
        public Filters? parent { get; set; }
        public List<Filters>? childFilters { get; set; }
        public List<Filters_Cat2> filters_Cat2s { get; set; }
        public List<Place_Filter> Place_Filters { get; set; }
    }
    public class FiltersConfiguration : IEntityTypeConfiguration<Filters>
    {
        public void Configure(EntityTypeBuilder<Filters> builder)
        {
            builder.HasIndex(u => u.title).IsUnique();
            builder.HasIndex(u => u.enTitle).IsUnique();
            builder.Property(p => p.title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.enTitle).HasMaxLength(50).IsRequired();
            builder.HasMany(p => p.childFilters).WithOne(p => p.parent).HasForeignKey(p => p.parentId);
        }
    }
}



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class TagCat : BaseEntity<long>
    {
        public long tagId { get; set; }
        public int catId { get; set; }
        public Tag tag { get; set; }
        public Cat3 cat3 { get; set; }
    }
    public class TagCatConfiguration : IEntityTypeConfiguration<TagCat>
    {
        public void Configure(EntityTypeBuilder<TagCat> builder)
        {
            builder.Property(p => p.tagId).IsRequired();
            builder.Property(p => p.catId).IsRequired();
            builder.HasOne(p => p.tag).WithMany(p => p.tagCats).HasForeignKey(p => p.tagId).IsRequired();
            builder.HasOne(p => p.cat3).WithMany(p => p.tagCats).HasForeignKey(p => p.catId).IsRequired();
        }
    }
}



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class TagCat : BaseEntity<long>
    {
        public long tagId { get; set; }
        public int cat2Id { get; set; }
        public Tag tag { get; set; }
        public Cat2 cat2 { get; set; }
    }
    public class TagCatConfiguration : IEntityTypeConfiguration<TagCat>
    {
        public void Configure(EntityTypeBuilder<TagCat> builder)
        {
            builder.Property(p => p.tagId).IsRequired();
            builder.Property(p => p.cat2Id).IsRequired();
            builder.HasOne(p => p.tag).WithMany(p => p.tagCats).HasForeignKey(p => p.tagId).IsRequired();
            builder.HasOne(p => p.cat2).WithMany(p => p.tagCats).HasForeignKey(p => p.cat2Id).IsRequired();
        }
    }
}

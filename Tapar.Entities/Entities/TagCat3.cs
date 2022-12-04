

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class TagCat3 : BaseEntity<long>
    {
        public long tagId { get; set; }
        public int cat3Id { get; set; }
        public Tag tag { get; set; }
        public Cat3 cat3 { get; set; }
    }
    public class TagCatConfiguration : IEntityTypeConfiguration<TagCat3>
    {
        public void Configure(EntityTypeBuilder<TagCat3> builder)
        {
            builder.Property(p => p.tagId).IsRequired();
            builder.Property(p => p.cat3Id).IsRequired();
            builder.HasOne(p => p.tag).WithMany(p => p.tagCats).HasForeignKey(p => p.tagId).IsRequired();
            builder.HasOne(p => p.cat3).WithMany(p => p.tagCat3s).HasForeignKey(p => p.cat3Id).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Tag:BaseEntity<long>
    {
        public string title { get; set; }
        public List<TagCat3> tagCats { get; set; }
    }
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasIndex(p => p.title).IsUnique();
            builder.Property(p => p.title).HasMaxLength(20).IsRequired();
        }
    }
}



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Tag:BaseEntity<long>
    {
        public string title { get; set; }
        public bool status { get; set; } = false;//true for user inserted tags
        public List<TagCat> tagCats { get; set; }
        public List<Place_Tag> place_Tags { get; set; }
    }
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(p => p.title).HasMaxLength(20).IsRequired();
        }
    }
}

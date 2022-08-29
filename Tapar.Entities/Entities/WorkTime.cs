using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class WorkTime:BaseEntity
    {
        public string title { get; set; }
        public List<Place> places { get; set; }
    }
    public class WorkTimeConfiguration : IEntityTypeConfiguration<WorkTime>
    {
        public void Configure(EntityTypeBuilder<WorkTime> builder)
        {
            builder.Property(p => p.title).HasMaxLength(20).IsRequired();
        }
    }
}

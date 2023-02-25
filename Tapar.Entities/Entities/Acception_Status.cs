using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Acception_Status : BaseEntity
    {
        public string Title { get; set; }
        public List<Place> Places { get; set; }
    }
    public class Acception_StatusConfiguration : IEntityTypeConfiguration<Acception_Status>
    {
        public void Configure(EntityTypeBuilder<Acception_Status> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(20);
            builder.HasData(
                new Acception_Status() { Id = 1, Title = "Waiting" },
                new Acception_Status() { Id = 2, Title = "Approved" },
                new Acception_Status() { Id = 3, Title = "Rejected" },
                new Acception_Status() { Id = 4, Title = "Inspecting" }
                );
        }
    }
}



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Report_Option : BaseEntity
    {
        public string Title { get; set; }
        public List<Place_Report> Place_Reports { get; set; }
    }
    public class Report_OptionConfiguration : IEntityTypeConfiguration<Report_Option>
    {
        public void Configure(EntityTypeBuilder<Report_Option> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.HasData(
                new Report_Option() { Id = 1, Title = "غلط املایی وجود دارد" },
                new Report_Option() { Id = 2, Title = "آدرس اشتباه است" },
                new Report_Option() { Id = 3, Title = "تلفن اشتباه است" },
                new Report_Option() { Id = 4, Title = "موبایل اشتباه است" },
                new Report_Option() { Id = 5, Title = "این کسب و کار وجود ندارد" }
                );
        }
    }
}

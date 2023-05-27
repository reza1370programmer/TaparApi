

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Place_Report : BaseEntity
    {
        public bool Status { get; set; } = false;
        public string? Other_Description { get; set; }
        public long PlaceId { get; set; }
        public DateTime ReportDate { get; set; }
        public Place Place { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public int ReportOptionId { get; set; }
        public Report_Option Report_Option { get; set; }
    }
    public class Place_ReportConfiguration : IEntityTypeConfiguration<Place_Report>
    {
        public void Configure(EntityTypeBuilder<Place_Report> builder)
        {
            builder.Property(p => p.Other_Description).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.PlaceId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.ReportOptionId).IsRequired();
            builder.HasOne(p => p.Place).WithMany(p => p.PlaceReport).HasForeignKey(p => p.PlaceId).IsRequired();
            builder.HasOne(p => p.User).WithMany(p => p.PlaceReport).HasForeignKey(p => p.UserId).IsRequired();
            builder.HasOne(p => p.Report_Option).WithMany(p => p.Place_Reports).HasForeignKey(p => p.ReportOptionId).IsRequired();
        }
    }
}

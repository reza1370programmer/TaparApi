

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class MedicalStaff : BaseEntity<long>
    {
        public string tablo { get; set; }
        public string address { get; set; }
        public string lng { get; set; }
        public string lat { get; set; }
        public string phone1 { get; set; }
        public string? phone2 { get; set; }
    }
    public class MedicalStaffConfiguration : IEntityTypeConfiguration<MedicalStaff>
    {
        public void Configure(EntityTypeBuilder<MedicalStaff> builder)
        {
            builder.Property(p => p.tablo).HasMaxLength(500).IsRequired();
            builder.Property(p => p.address).HasMaxLength(500).IsRequired();
            builder.Property(p => p.lng).HasMaxLength(20).IsRequired();
            builder.Property(p => p.lat).HasMaxLength(20).IsRequired();
            builder.Property(p => p.phone1).HasMaxLength(12).IsRequired();
            builder.Property(p => p.phone2).HasMaxLength(12).IsRequired(false);
        }
    }
}

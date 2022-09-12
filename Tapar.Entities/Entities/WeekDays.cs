
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class WeekDays : BaseEntity<long>
    {
        public int saturday { get; set; } = (int)TimeEnum.NoTime;
        public int sunday { get; set; } = (int)TimeEnum.NoTime;
        public int monday { get; set; } = (int)TimeEnum.NoTime;
        public int tuesday { get; set; } = (int)TimeEnum.NoTime;
        public int wednesday { get; set; } = (int)TimeEnum.NoTime;
        public int thursday { get; set; } = (int)TimeEnum.NoTime;
        public int friday { get; set; } = (int)TimeEnum.NoTime;
        public long? placeId { get; set; }
        public Place? place { get; set; }
    }
    public class WeekDaysConfiguration : IEntityTypeConfiguration<WeekDays>
    {
        public void Configure(EntityTypeBuilder<WeekDays> builder)
        {
            builder.HasOne(p => p.place).WithOne(p => p.weekDay).HasForeignKey<WeekDays>(p => p.placeId).IsRequired(false);
        }
    }
}

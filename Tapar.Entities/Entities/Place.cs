using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Place : SharedEntity
    {
        public string tablo { get; set; }
        public string? manager { get; set; }
        public string? service_description { get; set; }
        public string mob1 { get; set; }
        public string? mob2 { get; set; }
        public string phone1 { get; set; }
        public string? phone2 { get; set; }
        public string? phone3 { get; set; }
        public string? fax { get; set; }
        public string address { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string? bussiness_pic1 { get; set; }
        public string? bussiness_pic2 { get; set; }
        public string? bussiness_pic3 { get; set; }
        public string? personal_pic { get; set; }
        public string? visitCart_front { get; set; }
        public string? visitCart_back { get; set; }
        public string? special_message { get; set; }
        public string tags { get; set; }
        public string? gvalue { get; set; }
        public int? like_count { get; set; } = 0;
        public int? view_count { get; set; } = 0;
        public bool on_off { get; set; } = true;
        public WeekDays? weekDay { get; set; }
        public long userId { get; set; }
        public User user { get; set; }
        public int cat3Id { get; set; }
        public Cat3 cat3 { get; set; }
        public int work_time_id { get; set; }
        public List<Place_Tag>? place_Tags { get; set; }
        public WorkTime workTime { get; set; }
        public List<SubPlace> subPlaces { get; set; }
        public List<Comment> comments { get; set; }
        public List<ViewCount> viewCounts { get; set; }
        public List<LikeCount> likeCounts { get; set; }
        public List<Place_Filter> place_Filters { get; set; }
    }
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.Property(p => p.tablo).HasMaxLength(500).IsRequired();
            builder.Property(p => p.manager).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.service_description).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.mob1).HasMaxLength(11).IsRequired(true);
            builder.Property(p => p.mob2).HasMaxLength(11).IsRequired(false);
            builder.Property(p => p.phone1).HasMaxLength(10).IsRequired(true);
            builder.Property(p => p.phone2).HasMaxLength(10).IsRequired(false);
            builder.Property(p => p.phone3).HasMaxLength(10).IsRequired(false);
            builder.Property(p => p.fax).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.address).HasMaxLength(500).IsRequired(true);
            builder.Property(p => p.longitude).HasMaxLength(20).IsRequired();
            builder.Property(p => p.latitude).HasMaxLength(20).IsRequired();
            builder.Property(p => p.bussiness_pic1).HasMaxLength(25).IsRequired(false);
            builder.Property(p => p.bussiness_pic2).HasMaxLength(25).IsRequired(false);
            builder.Property(p => p.bussiness_pic3).HasMaxLength(25).IsRequired(false);
            builder.Property(p => p.personal_pic).HasMaxLength(25).IsRequired(false);
            builder.Property(p => p.visitCart_front).HasMaxLength(25).IsRequired(false);
            builder.Property(p => p.visitCart_back).HasMaxLength(25).IsRequired(false);
            builder.Property(p => p.special_message).HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.tags).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.gvalue).HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.like_count).IsRequired(false);
            builder.Property(p => p.view_count).IsRequired(false);
            builder.HasOne(p => p.cat3).WithMany(p => p.places).HasForeignKey(p => p.cat3Id).IsRequired();
            builder.HasOne(p => p.user).WithMany(p => p.places).HasForeignKey(p => p.userId).IsRequired();
            builder.HasOne(p => p.workTime).WithMany(p => p.places).HasForeignKey(p => p.work_time_id).IsRequired();
        }
    }
}

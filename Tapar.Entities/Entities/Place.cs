using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Place : SharedEntity
    {
        public string tablo { get; set; }
        public string manager { get; set; }
        public string? taparcode { get; set; }
        public string? service_description { get; set; } = null;
        public string? RejectedDescription { get; set; }
        public string? mob1 { get; set; } = null;
        public string? mob2 { get; set; } = null;
        public string? phone1 { get; set; } = null;
        public string? phone2 { get; set; } = null;
        public string? phone3 { get; set; } = null;
        public string? fax { get; set; } = null;
        public string? website { get; set; } = null;
        public string? email { get; set; } = null;
        public string? telegram { get; set; } = null;
        public string? instagram { get; set; } = null;
        public string? whatsapp { get; set; } = null;
        public string? address { get; set; } = null;
        public string? bussiness_pic1 { get; set; } = null;
        public string? bussiness_pic2 { get; set; } = null;
        public string? bussiness_pic3 { get; set; } = null;
        public string? personal_pic { get; set; } = null;
        public string? visitCart_front { get; set; } = null;
        public string? visitCart_back { get; set; } = null;
        public string? special_message { get; set; } = null;
        public int? like_count { get; set; } = 0;
        public int? view_count { get; set; } = 0;
        public bool on_off { get; set; } = true;
        public int locationId { get; set; }
        public Acception_Status Status { get; set; }
        public int StatusId { get; set; }
        public Location location { get; set; }
        public WeekDays? weekDay { get; set; }
        public long userId { get; set; }
        public User user { get; set; }
        public int workTimeId { get; set; }
        public WorkTime workTime { get; set; }
        public List<Comment> comments { get; set; }
        public List<LikeCount> likeCounts { get; set; }
        public List<PlaceTag> PlaceTags { get; set; }
        public List<Place_Report> PlaceReport { get; set; }

    }
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasIndex(p => p.taparcode).IsUnique();
            builder.HasIndex(p => p.tablo);
            builder.Property(p => p.tablo).HasMaxLength(500).IsRequired();
            builder.Property(p => p.manager).HasMaxLength(50).IsRequired();
            builder.Property(p => p.taparcode).HasMaxLength(30).IsRequired(false);
            builder.Property(p => p.service_description).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.RejectedDescription).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.mob1).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.mob2).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.phone1).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.phone2).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.phone3).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.fax).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.website).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.email).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.telegram).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.instagram).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.whatsapp).HasMaxLength(20).IsRequired(false);
            builder.Property(p => p.address).HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.bussiness_pic1).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.bussiness_pic2).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.bussiness_pic3).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.personal_pic).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.visitCart_front).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.visitCart_back).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.special_message).HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.like_count).IsRequired(false);
            builder.Property(p => p.view_count).IsRequired(false);
            builder.Property(p => p.locationId).IsRequired();
            builder.Property(p => p.StatusId).IsRequired();
            builder.HasOne(p => p.Status).WithMany(p => p.Places).HasForeignKey(p => p.StatusId).IsRequired();
            builder.HasOne(p => p.location).WithMany(p => p.places).HasForeignKey(p => p.locationId).IsRequired();
            builder.HasOne(p => p.user).WithMany(p => p.places).HasForeignKey(p => p.userId).IsRequired();
            builder.HasOne(p => p.workTime).WithMany(p => p.places).HasForeignKey(p => p.workTimeId).IsRequired();
        }
    }
}

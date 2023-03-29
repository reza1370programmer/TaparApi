﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaparApi.Data;

#nullable disable

namespace Tapar.Data.Migrations
{
    [DbContext(typeof(TaparDbContext))]
    [Migration("20230226083355_add-status-to-comments")]
    partial class addstatustocomments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tapar.Data.Entities.Acception_Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Acception_Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Waiting"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Rejected"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Inspecting"
                        });
                });

            modelBuilder.Entity("Tapar.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("create_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("placeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("placeId");

                    b.HasIndex("userId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Tapar.Data.Entities.LikeCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("likeDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("placeId")
                        .HasColumnType("bigint");

                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("placeId");

                    b.HasIndex("userId");

                    b.ToTable("LikeCounts");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("parentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            isActive = true,
                            name = "آذربایجان شرقی"
                        },
                        new
                        {
                            Id = 2,
                            isActive = true,
                            name = "بناب",
                            parentId = 1
                        });
                });

            modelBuilder.Entity("Tapar.Data.Entities.Place", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("RejectedDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("bussiness_pic1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("bussiness_pic2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("bussiness_pic3")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("cDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("fax")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("instagram")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("like_count")
                        .HasColumnType("int");

                    b.Property<int>("locationId")
                        .HasColumnType("int");

                    b.Property<string>("manager")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("mob1")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("mob2")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("modifiedUserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("on_off")
                        .HasColumnType("bit");

                    b.Property<string>("personal_pic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phone1")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("phone2")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("phone3")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("service_description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("special_message")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("tablo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("taparcode")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("telegram")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.Property<int?>("view_count")
                        .HasColumnType("int");

                    b.Property<string>("visitCart_back")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("visitCart_front")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("website")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("whatsapp")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("workTimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("locationId");

                    b.HasIndex("tablo");

                    b.HasIndex("taparcode")
                        .IsUnique()
                        .HasFilter("[taparcode] IS NOT NULL");

                    b.HasIndex("userId");

                    b.HasIndex("workTimeId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Place_Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Other_Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("PlaceId")
                        .HasColumnType("bigint");

                    b.Property<int>("ReportOptionId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("ReportOptionId");

                    b.HasIndex("UserId");

                    b.ToTable("Place_Reports");
                });

            modelBuilder.Entity("Tapar.Data.Entities.PlaceTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("PlaceId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("TagId");

                    b.ToTable("PlaceTags");
                });

            modelBuilder.Entity("Tapar.Data.Entities.RefreshTokens", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("expirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("refreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("superAdminId")
                        .HasColumnType("int");

                    b.Property<long?>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("superAdminId");

                    b.HasIndex("userId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Report_Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Report_Options");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "غلط املایی وجود دارد"
                        },
                        new
                        {
                            Id = 2,
                            Title = "آدرس اشتباه است"
                        },
                        new
                        {
                            Id = 3,
                            Title = "تلفن اشتباه است"
                        },
                        new
                        {
                            Id = 4,
                            Title = "موبایل اشتباه است"
                        },
                        new
                        {
                            Id = 5,
                            Title = "این کسب و کار وجود ندارد"
                        });
                });

            modelBuilder.Entity("Tapar.Data.Entities.SuperAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("adminType")
                        .HasColumnType("int");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("SuperAdmins");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("title")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Tapar.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tapar.Data.Entities.WeekDays", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("friday")
                        .HasColumnType("int");

                    b.Property<int>("monday")
                        .HasColumnType("int");

                    b.Property<long?>("placeId")
                        .HasColumnType("bigint");

                    b.Property<int>("saturday")
                        .HasColumnType("int");

                    b.Property<int>("sunday")
                        .HasColumnType("int");

                    b.Property<int>("thursday")
                        .HasColumnType("int");

                    b.Property<int>("tuesday")
                        .HasColumnType("int");

                    b.Property<int>("wednesday")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("placeId")
                        .IsUnique()
                        .HasFilter("[placeId] IS NOT NULL");

                    b.ToTable("WeekDays");
                });

            modelBuilder.Entity("Tapar.Data.Entities.WorkTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("WorkTimes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            title = "شبانه روزی"
                        },
                        new
                        {
                            Id = 2,
                            title = "اداری"
                        },
                        new
                        {
                            Id = 3,
                            title = "خاص"
                        });
                });

            modelBuilder.Entity("Tapar.Data.Entities.Comment", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Place", "place")
                        .WithMany("comments")
                        .HasForeignKey("placeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.User", "user")
                        .WithMany("Comments")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("place");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Tapar.Data.Entities.LikeCount", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Place", "place")
                        .WithMany("likeCounts")
                        .HasForeignKey("placeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.User", "User")
                        .WithMany("LikeCounts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("place");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Place", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Acception_Status", "Status")
                        .WithMany("Places")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.Location", "location")
                        .WithMany("places")
                        .HasForeignKey("locationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.User", "user")
                        .WithMany("places")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.WorkTime", "workTime")
                        .WithMany("places")
                        .HasForeignKey("workTimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("location");

                    b.Navigation("user");

                    b.Navigation("workTime");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Place_Report", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Place", "Place")
                        .WithMany("PlaceReport")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.Report_Option", "Report_Option")
                        .WithMany("Place_Reports")
                        .HasForeignKey("ReportOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.User", "User")
                        .WithMany("PlaceReport")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("Report_Option");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tapar.Data.Entities.PlaceTag", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Place", "Place")
                        .WithMany("PlaceTags")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.Tag", "Tag")
                        .WithMany("PlaceTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Tapar.Data.Entities.RefreshTokens", b =>
                {
                    b.HasOne("Tapar.Data.Entities.SuperAdmin", "superAdmin")
                        .WithMany("refreshTokens")
                        .HasForeignKey("superAdminId");

                    b.HasOne("Tapar.Data.Entities.User", "user")
                        .WithMany("refreshTokens")
                        .HasForeignKey("userId");

                    b.Navigation("superAdmin");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Tapar.Data.Entities.WeekDays", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Place", "place")
                        .WithOne("weekDay")
                        .HasForeignKey("Tapar.Data.Entities.WeekDays", "placeId");

                    b.Navigation("place");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Acception_Status", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Location", b =>
                {
                    b.Navigation("places");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Place", b =>
                {
                    b.Navigation("PlaceReport");

                    b.Navigation("PlaceTags");

                    b.Navigation("comments");

                    b.Navigation("likeCounts");

                    b.Navigation("weekDay");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Report_Option", b =>
                {
                    b.Navigation("Place_Reports");
                });

            modelBuilder.Entity("Tapar.Data.Entities.SuperAdmin", b =>
                {
                    b.Navigation("refreshTokens");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Tag", b =>
                {
                    b.Navigation("PlaceTags");
                });

            modelBuilder.Entity("Tapar.Data.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikeCounts");

                    b.Navigation("PlaceReport");

                    b.Navigation("places");

                    b.Navigation("refreshTokens");
                });

            modelBuilder.Entity("Tapar.Data.Entities.WorkTime", b =>
                {
                    b.Navigation("places");
                });
#pragma warning restore 612, 618
        }
    }
}

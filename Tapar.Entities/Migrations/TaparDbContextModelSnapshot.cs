﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaparApi.Data;

#nullable disable

namespace Tapar.Data.Migrations
{
    [DbContext(typeof(TaparDbContext))]
    partial class TaparDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tapar.Data.Entities.Cat1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("abbreviation")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("gdesc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cat1s");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Cat2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("cat1Id")
                        .HasColumnType("int");

                    b.Property<string>("gdesc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("cat1Id");

                    b.ToTable("Cat2s");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Cat3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("cat2Id")
                        .HasColumnType("int");

                    b.Property<string>("gdesc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("cat2Id");

                    b.ToTable("Cat3s");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("approv_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("approv_date_userId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("create_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("placeId")
                        .HasColumnType("bigint");

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

            modelBuilder.Entity("Tapar.Data.Entities.Filters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("enTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("parentId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("enTitle")
                        .IsUnique();

                    b.HasIndex("parentId");

                    b.HasIndex("title")
                        .IsUnique();

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Filters_Cat2", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("cat2Id")
                        .HasColumnType("int");

                    b.Property<int>("filterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cat2Id");

                    b.HasIndex("filterId");

                    b.ToTable("Filters_Cat2s");
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

                    b.Property<string>("abbreviation")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("latitude")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("longitude")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("parentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("abbreviation")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Tapar.Data.Entities.MedicalStaff", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("lat")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("lng")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("phone1")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("phone2")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("tablo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("MedicalStaffs");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Place", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
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

                    b.Property<int>("cat3Id")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("fax")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("gvalue")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("instagram")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("latitude")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("like_count")
                        .HasColumnType("int");

                    b.Property<int>("locationId")
                        .HasColumnType("int");

                    b.Property<string>("longitude")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

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

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("tablo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("tags")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("taparcode")
                        .IsRequired()
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

                    b.HasIndex("cat3Id");

                    b.HasIndex("locationId");

                    b.HasIndex("tablo");

                    b.HasIndex("tags");

                    b.HasIndex("userId");

                    b.HasIndex("workTimeId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Place_Filter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("filterId")
                        .HasColumnType("int");

                    b.Property<long>("placeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("filterId");

                    b.HasIndex("placeId");

                    b.ToTable("Place_Filters");
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

            modelBuilder.Entity("Tapar.Data.Entities.SpecialTypeField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("cat2Id")
                        .HasColumnType("int");

                    b.Property<string>("enTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isRequired")
                        .HasColumnType("bit");

                    b.Property<string>("maxLength")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("cat2Id");

                    b.ToTable("SpecialTypeFields");
                });

            modelBuilder.Entity("Tapar.Data.Entities.SubPlace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("internalPhone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("personalPic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("placeId")
                        .HasColumnType("bigint");

                    b.Property<string>("semat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("placeId");

                    b.ToTable("SubPlaces");
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

            modelBuilder.Entity("Tapar.Data.Entities.TagCat3", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("cat3Id")
                        .HasColumnType("int");

                    b.Property<long>("tagId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("cat3Id");

                    b.HasIndex("tagId");

                    b.ToTable("TagCat3s");
                });

            modelBuilder.Entity("Tapar.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("password")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tapar.Data.Entities.ViewCount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("clientDetail")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<long>("placeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("userId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("viewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("placeId");

                    b.HasIndex("userId");

                    b.ToTable("ViewCounts");
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
                });

            modelBuilder.Entity("Tapar.Data.Entities.Cat2", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Cat1", "cat1")
                        .WithMany("cat2s")
                        .HasForeignKey("cat1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("cat1");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Cat3", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Cat2", "cat2")
                        .WithMany("cat3s")
                        .HasForeignKey("cat2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("cat2");
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

            modelBuilder.Entity("Tapar.Data.Entities.Filters", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Filters", "parent")
                        .WithMany("childFilters")
                        .HasForeignKey("parentId");

                    b.Navigation("parent");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Filters_Cat2", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Cat2", "cat2")
                        .WithMany("filters_Cat2s")
                        .HasForeignKey("cat2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.Filters", "filter")
                        .WithMany("filters_Cat2s")
                        .HasForeignKey("filterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("cat2");

                    b.Navigation("filter");
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
                    b.HasOne("Tapar.Data.Entities.Cat3", "cat3")
                        .WithMany("places")
                        .HasForeignKey("cat3Id")
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

                    b.Navigation("cat3");

                    b.Navigation("location");

                    b.Navigation("user");

                    b.Navigation("workTime");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Place_Filter", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Filters", "filter")
                        .WithMany("Place_Filters")
                        .HasForeignKey("filterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.Place", "place")
                        .WithMany("place_Filters")
                        .HasForeignKey("placeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("filter");

                    b.Navigation("place");
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

            modelBuilder.Entity("Tapar.Data.Entities.SpecialTypeField", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Cat2", "cat2")
                        .WithMany("SpecialTypeFields")
                        .HasForeignKey("cat2Id");

                    b.Navigation("cat2");
                });

            modelBuilder.Entity("Tapar.Data.Entities.SubPlace", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Place", "place")
                        .WithMany("subPlaces")
                        .HasForeignKey("placeId");

                    b.Navigation("place");
                });

            modelBuilder.Entity("Tapar.Data.Entities.TagCat3", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Cat3", "cat3")
                        .WithMany("tagCat3s")
                        .HasForeignKey("cat3Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.Tag", "tag")
                        .WithMany("tagCats")
                        .HasForeignKey("tagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("cat3");

                    b.Navigation("tag");
                });

            modelBuilder.Entity("Tapar.Data.Entities.ViewCount", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Place", "place")
                        .WithMany("viewCounts")
                        .HasForeignKey("placeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tapar.Data.Entities.User", "User")
                        .WithMany("ViewCounts")
                        .HasForeignKey("userId");

                    b.Navigation("User");

                    b.Navigation("place");
                });

            modelBuilder.Entity("Tapar.Data.Entities.WeekDays", b =>
                {
                    b.HasOne("Tapar.Data.Entities.Place", "place")
                        .WithOne("weekDay")
                        .HasForeignKey("Tapar.Data.Entities.WeekDays", "placeId");

                    b.Navigation("place");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Cat1", b =>
                {
                    b.Navigation("cat2s");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Cat2", b =>
                {
                    b.Navigation("SpecialTypeFields");

                    b.Navigation("cat3s");

                    b.Navigation("filters_Cat2s");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Cat3", b =>
                {
                    b.Navigation("places");

                    b.Navigation("tagCat3s");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Filters", b =>
                {
                    b.Navigation("Place_Filters");

                    b.Navigation("childFilters");

                    b.Navigation("filters_Cat2s");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Location", b =>
                {
                    b.Navigation("places");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Place", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("likeCounts");

                    b.Navigation("place_Filters");

                    b.Navigation("subPlaces");

                    b.Navigation("viewCounts");

                    b.Navigation("weekDay");
                });

            modelBuilder.Entity("Tapar.Data.Entities.SuperAdmin", b =>
                {
                    b.Navigation("refreshTokens");
                });

            modelBuilder.Entity("Tapar.Data.Entities.Tag", b =>
                {
                    b.Navigation("tagCats");
                });

            modelBuilder.Entity("Tapar.Data.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikeCounts");

                    b.Navigation("ViewCounts");

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

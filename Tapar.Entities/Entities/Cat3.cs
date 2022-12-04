﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities
{
    public class Cat3:BaseEntity
    {
        public string name { get; set; }
        public string gdesc { get; set; }
        public Cat2 cat2 { get; set; }
        public int cat2Id { get; set; }
        public List<Place> places { get; set; }
        public List<TagCat3> tagCat3s { get; set; }
    }
    public class Cat3Configuration : IEntityTypeConfiguration<Cat3>
    {
        public void Configure(EntityTypeBuilder<Cat3> builder)
        {
            builder.Property(p => p.name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.gdesc).HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.cat2Id).IsRequired();
            builder.HasOne(p => p.cat2).WithMany(p => p.cat3s).HasForeignKey(p => p.cat2Id);
        }
    }
}

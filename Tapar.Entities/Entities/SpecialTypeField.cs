using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class SpecialTypeField : BaseEntity
{
    public string title { get; set; }
    public string enTitle { get; set; }
    public string maxLength { get; set; }
    public bool isRequired { get; set; } = false;
    public int? cat2Id { get; set; }
    public Cat2? cat2 { get; set; }
}
public class SpecialTypeFieldConfiguration : IEntityTypeConfiguration<SpecialTypeField>
{
    public void Configure(EntityTypeBuilder<SpecialTypeField> builder)
    {
        builder.Property(p => p.maxLength).HasMaxLength(5).IsRequired();
        builder.Property(p => p.title).HasMaxLength(50).IsRequired();
        builder.Property(p => p.enTitle).HasMaxLength(50).IsRequired();
        builder.HasOne(p => p.cat2).WithMany(p => p.SpecialTypeFields).HasForeignKey(p => p.cat2Id).IsRequired(false);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace TaparApi.Data.Entities;

public class SpecialTypeField : BaseEntity
{
    public string title { get; set; }
    public string enTitle { get; set; }
    public int? cat2Id { get; set; }
    public Cat2? cat2 { get; set; }
    public int fieldTypeId { get; set; }
    public FieldType FieldType { get; set; }
}
public class SpecialTypeFieldConfiguration : IEntityTypeConfiguration<SpecialTypeField>
{
    public void Configure(EntityTypeBuilder<SpecialTypeField> builder)
    {
        builder.Property(p => p.title).HasMaxLength(50).IsRequired();
        builder.Property(p => p.enTitle).HasMaxLength(50).IsRequired();
        builder.HasOne(p => p.cat2).WithMany(p => p.SpecialTypeFields).HasForeignKey(p => p.cat2Id).IsRequired(false);
        builder.HasOne(p => p.FieldType).WithMany(p => p.SpecialTypeFields).HasForeignKey(p => p.fieldTypeId).IsRequired(true);
    }
}
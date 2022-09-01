using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class FieldType:BaseEntity
{
    public string name { get; set; }
    public List<SpecialTypeField> SpecialTypeFields { get; set; }
}
public class FieldTypeConfiguration : IEntityTypeConfiguration<FieldType>
{
    public void Configure(EntityTypeBuilder<FieldType> builder)
    {
        builder.Property(p => p.name).HasMaxLength(50).IsRequired();
    }
}
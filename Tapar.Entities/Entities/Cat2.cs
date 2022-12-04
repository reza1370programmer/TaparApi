using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace Tapar.Data.Entities;

public class Cat2 : BaseEntity
{
    public string name { get; set; }
    public string? gdesc { get; set; }
    public Cat1 cat1 { get; set; }
    public int cat1Id { get; set; }
    public List<Cat3> cat3s { get; set; }
    public List<SpecialTypeField>? SpecialTypeFields { get; set; }
    public List<Filters_Cat2>? filters_Cat2s { get; set; }
}
public class Cat2Configuration : IEntityTypeConfiguration<Cat2>
{
    public void Configure(EntityTypeBuilder<Cat2> builder)
    {
        builder.Property(p => p.name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.gdesc).HasMaxLength(500).IsRequired(false);
        builder.Property(p => p.cat1Id).IsRequired();
        builder.HasOne(p => p.cat1).WithMany(p => p.cat2s).HasForeignKey(p => p.cat1Id).IsRequired();
    }
}
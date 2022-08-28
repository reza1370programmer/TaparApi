using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapar.Data.Common;

namespace TaparApi.Data.Entities;

public class Cat1 : BaseEntity
{
    public string name { get; set; }
    public string gdesc { get; set; }
    public List<Cat2> cat2s { get; set; }
}
public class Cat1Configuration : IEntityTypeConfiguration<Cat1>
{
    public void Configure(EntityTypeBuilder<Cat1> builder)
    {
        builder.Property(p => p.name).HasMaxLength(100).IsRequired(false);
        builder.Property(p => p.gdesc).HasMaxLength(500).IsRequired(false);
    }
}
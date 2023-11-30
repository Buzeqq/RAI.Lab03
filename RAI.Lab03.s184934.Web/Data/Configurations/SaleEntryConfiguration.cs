using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

public sealed class SaleEntryConfiguration : IEntityTypeConfiguration<SaleEntry>
{
    public void Configure(EntityTypeBuilder<SaleEntry> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(new IdValueConverter());

        builder
            .HasOne(e => e.Water)
            .WithMany()
            .IsRequired();
    }
}
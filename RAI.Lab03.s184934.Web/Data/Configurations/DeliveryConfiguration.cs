using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

internal sealed class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .HasConversion(new IdValueConverter());

        builder.Property(d => d.NumberOfPallets)
            .HasConversion(n => n.Value,
                n => new NumberOfPallets(n));

        builder.HasOne(d => d.Supplier)
            .WithMany()
            .IsRequired();
        builder.HasMany(d => d.Pallets)
            .WithOne()
            .IsRequired();
    }
}
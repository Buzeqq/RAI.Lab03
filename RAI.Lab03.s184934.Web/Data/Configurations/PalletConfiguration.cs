using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

internal sealed class PalletConfiguration : IEntityTypeConfiguration<Pallet>
{
    public void Configure(EntityTypeBuilder<Pallet> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(d => d.Id)
            .HasConversion(new IdValueConverter());

        builder.HasOne(p => p.Water)
            .WithMany()
            .IsRequired();
    }
}
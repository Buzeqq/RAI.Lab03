using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

internal sealed class MineralWaterConfiguration : IEntityTypeConfiguration<MineralWater>
{
    public void Configure(EntityTypeBuilder<MineralWater> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(new IdValueConverter());

        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => new WaterName(x))
            .IsRequired();

        builder
            .HasOne(x => x.Type)
            .WithMany()
            .IsRequired();

        builder
            .HasOne(x => x.Producer)
            .WithMany()
            .IsRequired();

        builder
            .Property(x => x.Ph)
            .HasConversion(x => x.Value, x => new PhValue(x))
            .IsRequired();

        builder
            .HasMany(x => x.Cations)
            .WithMany();

        builder
            .HasMany(x => x.Anions)
            .WithMany();

        builder
            .HasOne(x => x.Packaging)
            .WithMany();
    }
}
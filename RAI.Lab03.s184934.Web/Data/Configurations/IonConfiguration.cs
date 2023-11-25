using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

internal sealed class IonConfiguration : IEntityTypeConfiguration<Ion>
{
    public void Configure(EntityTypeBuilder<Ion> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(new IdValueConverter());

        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => new IonName(x))
            .IsRequired();

        builder
            .Property(x => x.Symbol)
            .HasConversion(x => x.Value, x => new IonSymbol(x))
            .IsRequired();

        builder
            .Property(x => x.Content)
            .HasConversion(x => x.Content, x => new ContentInGramsPerLiter(x))
            .IsRequired();

        builder
            .HasDiscriminator<string>("Type")
            .HasValue<Cation>(nameof(Cation))
            .HasValue<Anion>(nameof(Anion));
    }
}
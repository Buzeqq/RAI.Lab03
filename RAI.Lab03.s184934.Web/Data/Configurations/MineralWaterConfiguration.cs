using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

internal sealed class WaterTypeConfiguration : IEntityTypeConfiguration<WaterType>
{
    public void Configure(EntityTypeBuilder<WaterType> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(new IdValueConverter());

        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => new WaterTypeName(x))
            .IsRequired();
    }
}

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

internal sealed class PackagingConfiguration : IEntityTypeConfiguration<Packaging>
{
    public void Configure(EntityTypeBuilder<Packaging> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(new IdValueConverter());
    }
}

internal sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(new IdValueConverter());

        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => new CompanyName(x))
            .IsRequired();

        builder
            .Property(x => x.PhoneNumber)
            .HasConversion(x => x.Value, x => new PhoneNumber(x))
            .IsRequired();

        builder
            .Property(x => x.Email)
            .HasConversion(x => x.Address, x => new Email(x))
            .IsRequired();

        builder
            .HasDiscriminator<string>("Type")
            .HasValue<Producer>(nameof(Producer))
            .HasValue<Supplier>(nameof(Supplier));
    }
}

internal sealed class IdValueConverter : ValueConverter<Id, Guid>
{
    public IdValueConverter(ConverterMappingHints? mappingHints = null)
        : base(x => x.Value, x => new Id(x), mappingHints)
    {
    }
}
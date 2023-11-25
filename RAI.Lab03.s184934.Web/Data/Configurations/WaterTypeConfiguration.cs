using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

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
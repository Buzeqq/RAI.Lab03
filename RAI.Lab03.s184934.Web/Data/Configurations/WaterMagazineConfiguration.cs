using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

public class WaterMagazineConfiguration : IEntityTypeConfiguration<WaterMagazine>
{
    public void Configure(EntityTypeBuilder<WaterMagazine> builder)
    {
        builder.HasKey(m => m.WaterId);
        builder.Property(m => m.WaterId)
            .HasConversion(new IdValueConverter());
    }
}
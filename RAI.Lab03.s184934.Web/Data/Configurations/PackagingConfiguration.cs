using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

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
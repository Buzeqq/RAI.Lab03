using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Web.Data.Configurations;

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
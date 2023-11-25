using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;
using RAI.Lab03.s184934.Web.Data.DTO.Packaging;

namespace RAI.Lab03.s184934.Web.Data;

public static class Extensions
{
    public static CompanyType GetCompanyType(this Company company) =>
        company switch
        {
            Producer => CompanyType.Producer,
            Supplier => CompanyType.Supplier,
            _ => throw new ArgumentOutOfRangeException(nameof(company))
        };

    public static IonDto AsDto(this Ion ion) =>
        new()
        {
            Id = ion.Id,
            Name = ion.Name,
            Symbol = ion.Symbol,
            Content = ion.Content,
            Type = ion.GetIonType()
        };

    public static IonType GetIonType(this Ion ion) =>
        ion switch
        {
            Cation => IonType.Cation,
            Anion => IonType.Anion,
            _ => throw new ArgumentOutOfRangeException(nameof(ion))
        };

    public static CompanyDto AsDto(this Company company) =>
        new()
        {
            Id = company.Id,
            Name = company.Name,
            Email = company.Email,
            PhoneNumber = company.PhoneNumber,
            Type = company.GetCompanyType()
        };

    public static PackagingDto AsDto(this Packaging packaging) =>
        new()
        {
            Id = packaging.Id,
            Name = packaging.Name,
            Volume = packaging.Volume
        };
}
using System.Reflection;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.DTO.Company;

public sealed record AddCompanyDto(string Name, string PhoneNumber, string Email, CompanyType Type)
{
    public Core.Entities.Company AsCompany() => Type switch
    {
        CompanyType.Producer => new Producer(Guid.NewGuid(), Name, PhoneNumber, Email),
        CompanyType.Supplier => new Supplier(Guid.NewGuid(), Name, PhoneNumber, Email),
        _ => throw new NotImplementedException()
    };
}

public sealed record UpdateCompanyDto(Guid Id, string Name, string PhoneNumber, string Email);

public sealed record CompanyDetailsDto(Guid Id, string Name, string PhoneNumber, string Email, CompanyType Type);

public sealed record DeleteCompanyDto(Guid Id, string Name, string PhoneNumber, string Email, CompanyType Type);

public enum CompanyType
{
    Producer,
    Supplier
}

public static class Extensions
{
    public static CompanyType GetCompanyType(this Core.Entities.Company company)
    {
        return company switch
        {
            Producer => CompanyType.Producer,
            Supplier => CompanyType.Supplier,
            _ => throw new ArgumentOutOfRangeException(nameof(company))
        };
    }
}
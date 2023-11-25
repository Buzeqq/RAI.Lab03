using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Web.Data.DTO.Company;

namespace RAI.Lab03.s184934.Web.Data;

public static class Extensions
{
    public static CompanyType GetCompanyType(this Company company)
    {
        return company switch
        {
            Producer => CompanyType.Producer,
            Supplier => CompanyType.Supplier,
            _ => throw new ArgumentOutOfRangeException(nameof(company))
        };
    }
}
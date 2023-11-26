using System.ComponentModel.DataAnnotations;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.DTO.Company;

public sealed class CompanyDto
{
    public Guid Id { get; init; }

    [Required]
    [StringLength(100, MinimumLength = 5)] 
    public string Name { get; init; }

    [Required]
    [Phone] 
    public string PhoneNumber { get; init; }

    [Required]
    [EmailAddress] 
    public string Email { get; init; }

    [Required]
    public CompanyType Type { get; init; }
    
    public CompanyDto()
    {
    }

    public CompanyDto(Guid id, string name, string phoneNumber, string email, CompanyType type)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Type = type;
    }

    public Core.Entities.Company AsCompany(Guid id)
    {
        return Type switch
        {
            CompanyType.Producer => new Producer(id, Name, PhoneNumber, Email),
            CompanyType.Supplier => new Supplier(id, Name, PhoneNumber, Email),
            _ => throw new NotImplementedException()
        };
    }
}
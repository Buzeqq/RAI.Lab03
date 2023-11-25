using System.ComponentModel.DataAnnotations;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.DTO.Company;

public sealed class CompanyDto
{
    public CompanyDto() {}
    
    public CompanyDto(Guid id, string name, string phoneNumber, string email, CompanyType type)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Type = type;
    }

    public Core.Entities.Company AsCompany() => Type switch
    {
        CompanyType.Producer => new Producer(Id, Name, PhoneNumber, Email),
        CompanyType.Supplier => new Supplier(Id, Name, PhoneNumber, Email),
        _ => throw new NotImplementedException()
    };
    
    [Required]
    public Guid Id { get; init; }
    [StringLength(100, MinimumLength = 5)]
    public string Name { get; init; }
    [Phone]
    public string PhoneNumber { get; init; }
    [EmailAddress]
    public string Email { get; init; }
    public CompanyType Type { get; init; }

    public void Deconstruct(out Guid id, out string name, out string phoneNumber, out string email, out CompanyType type)
    {
        id = Id;
        name = Name;
        phoneNumber = PhoneNumber;
        email = Email;
        type = Type;
    }
}
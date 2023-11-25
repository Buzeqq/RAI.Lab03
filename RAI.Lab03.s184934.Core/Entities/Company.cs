using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public abstract class Company
{
    protected Company(Id id, CompanyName name, PhoneNumber phoneNumber, Email email)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public Id Id { get; private set; }
    public CompanyName Name { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Email Email { get; set; }
}

public sealed class Producer : Company
{
    public Producer(Id id, CompanyName name, PhoneNumber phoneNumber, Email email) : base(id, name, phoneNumber, email)
    {
    }
}

public sealed class Supplier : Company
{
    public Supplier(Id id, CompanyName name, PhoneNumber phoneNumber, Email email) : base(id, name, phoneNumber, email)
    {
    }
}
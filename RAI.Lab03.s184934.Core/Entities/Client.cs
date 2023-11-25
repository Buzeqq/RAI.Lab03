using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class Client
{
    public Id Id { get; }
    public PersonName Name { get; }
    public PhoneNumber PhoneNumber { get; }
    public Email Email { get; }
}
using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record CompanyName
{
    private string Value { get; }

    public CompanyName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueException(typeof(CompanyName), value);
        }
        
        Value = value;
    }

    public static implicit operator string(CompanyName name) => name.Value;
    public static implicit operator CompanyName(string name) => new(name);
}
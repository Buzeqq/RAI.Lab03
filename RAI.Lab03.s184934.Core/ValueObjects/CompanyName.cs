using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record CompanyName
{
    public CompanyName(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidValueException(typeof(CompanyName), value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(CompanyName name)
    {
        return name.Value;
    }

    public static implicit operator CompanyName(string name)
    {
        return new CompanyName(name);
    }
}
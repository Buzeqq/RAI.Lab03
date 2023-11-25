using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record PersonName
{
    public PersonName(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidValueException(typeof(PersonName), value);

        Value = value;
    }

    private string Value { get; }

    public static implicit operator string(PersonName name)
    {
        return name.Value;
    }

    public static implicit operator PersonName(string name)
    {
        return new PersonName(name);
    }
}
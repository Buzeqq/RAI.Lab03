using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record PersonName
{
    private string Value { get; }

    public PersonName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueException(typeof(PersonName), value);
        }
        
        Value = value;
    }

    public static implicit operator string(PersonName name) => name.Value;
    public static implicit operator PersonName(string name) => new(name);
}
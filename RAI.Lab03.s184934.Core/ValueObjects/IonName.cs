using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record IonName
{
    public string Value { get; }

    public IonName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueException(typeof(WaterTypeName), value);
        }

        Value = value;
    }

    public static implicit operator string(IonName name) => name.Value;
    public static implicit operator IonName(string name) => new(name);
}
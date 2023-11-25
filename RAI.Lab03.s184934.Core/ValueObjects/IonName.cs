using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record IonName
{
    public IonName(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidValueException(typeof(WaterTypeName), value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(IonName name)
    {
        return name.Value;
    }

    public static implicit operator IonName(string name)
    {
        return new IonName(name);
    }
}
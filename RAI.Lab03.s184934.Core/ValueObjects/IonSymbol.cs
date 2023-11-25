using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record IonSymbol
{
    public string Value { get; }

    public IonSymbol(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueException(typeof(WaterTypeName), value);
        }

        Value = value;
    }

    public static implicit operator string(IonSymbol name) => name.Value;
    public static implicit operator IonSymbol(string name) => new(name);
}
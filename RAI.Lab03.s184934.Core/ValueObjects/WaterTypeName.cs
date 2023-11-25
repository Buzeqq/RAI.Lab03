using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record WaterTypeName
{
    public WaterTypeName(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidValueException(typeof(WaterTypeName), value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(WaterTypeName name)
    {
        return name.Value;
    }

    public static implicit operator WaterTypeName(string name)
    {
        return new WaterTypeName(name);
    }
}
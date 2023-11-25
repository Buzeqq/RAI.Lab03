using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record WaterTypeName
{
    public string Value { get; }

    public WaterTypeName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueException(typeof(WaterTypeName), value);
        }

        Value = value;
    }

    public static implicit operator string(WaterTypeName name) => name.Value;
    public static implicit operator WaterTypeName(string name) => new(name);
}
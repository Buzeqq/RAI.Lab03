using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record WaterName
{
    public const int MinLength = 3;
    public const int MaxLength = 50;

    public WaterName(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidValueException(typeof(WaterName), value);

        if (value.Length is < MinLength or > MaxLength) throw new InvalidWaterNameLengthException(value.Length);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(WaterName name)
    {
        return name.Value;
    }

    public static implicit operator WaterName(string name)
    {
        return new WaterName(name);
    }
}
using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record PhValue
{
    public const float DefaultValue = 7.0f;
    public const float MinValue = 5.0f;
    public const float MaxValue = 9.0f;

    public PhValue(float value)
    {
        if (value is < MinValue or > MaxValue) throw new InvalidPhValueException(value);
    }

    public float Value { get; }
}
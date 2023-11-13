using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Exceptions;

public sealed class InvalidPhValueException : WaterWarehouseException
{
    public InvalidPhValueException(float value) : base($"Invalid pH value: {value}. Allowed value range: <{PhValue.MinValue}, {PhValue.MaxValue}>")
    {
    }
}
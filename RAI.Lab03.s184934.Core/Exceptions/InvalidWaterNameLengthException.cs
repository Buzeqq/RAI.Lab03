using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Exceptions;

public sealed class InvalidWaterNameLengthException : WaterWarehouseException
{
    public InvalidWaterNameLengthException(int length) 
        : base($"Invalid water name length: {length}, must be between {WaterName.MinLength} and {WaterName.MaxLength} characters long")
    {
        
    }
}
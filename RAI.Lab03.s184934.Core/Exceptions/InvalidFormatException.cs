namespace RAI.Lab03.s184934.Core.Exceptions;

public sealed class InvalidFormatException : WaterWarehouseException
{
    public InvalidFormatException(string content) : base($"Invalid format: {content}")
    {
    }
}
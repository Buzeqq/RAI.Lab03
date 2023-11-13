namespace RAI.Lab03.s184934.Core.Exceptions;

public sealed class EmptyIdException : WaterWarehouseException
{
    public EmptyIdException() : base("The id was empty")
    {
        
    }
}
using System.Reflection;

namespace RAI.Lab03.s184934.Core.Exceptions;

public sealed class InvalidValueException : WaterWarehouseException
{
    public InvalidValueException(MemberInfo type, string value) : base($"Invalid {type.Name} value: [{value}]")
    {
        
    }
}
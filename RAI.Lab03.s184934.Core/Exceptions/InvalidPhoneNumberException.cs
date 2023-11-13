using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Exceptions;

public sealed class InvalidPhoneNumberException : WaterWarehouseException
{
    public InvalidPhoneNumberException(string value) 
        : base($"Invalid phone number: [{value}]. Allowed characters: {string.Join(", ", PhoneNumber.AllowedCharacters)}")
    {
    }
}
using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record PhoneNumber
{
    public string Value { get; }
    public static readonly IEnumerable<char> AllowedCharacters = new[]
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '(', ')', '-', ' '
    }; 
    
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueException(typeof(PhoneNumber), value);
        }

        if (value.Any(c => !AllowedCharacters.Contains(c)))
        {
            throw new InvalidPhoneNumberException(value);
        }
        
        Value = value;
    }

    public static implicit operator string(PhoneNumber name) => name.Value;
    public static implicit operator PhoneNumber(string name) => new(name);
}
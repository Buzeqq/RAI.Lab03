using System.Text.RegularExpressions;
using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public partial record Email
{
    public Email(string address)
    {
        address = address.Trim();
        if (!IsValidEmail(address)) throw new InvalidValueException(typeof(Email), address);

        Address = address;
    }

    public string Address { get; }

    private static bool IsValidEmail(string email)
    {
        // This regular expression is a simple one and may not cover all cases.
        // It checks for a basic structure: local-part@domain
        return EmailRegex().IsMatch(email);
    }

    [GeneratedRegex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();

    public static implicit operator Email(string email)
    {
        return new Email(email);
    }

    public static implicit operator string(Email email)
    {
        return email.Address;
    }
}
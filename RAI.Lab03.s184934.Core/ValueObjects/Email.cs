using RAI.Lab03.s184934.Core.Exceptions;
using System.Text.RegularExpressions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public partial record Email
{
    public string Address { get; }

    public Email(string address)
    {
        address = address.Trim();
        if (!IsValidEmail(address))
        {
            throw new InvalidValueException(typeof(Email), address);
        }

        Address = address;
    }

    private static bool IsValidEmail(string email)
    {
        // This regular expression is a simple one and may not cover all cases.
        // It checks for a basic structure: local-part@domain
        return EmailRegex().IsMatch(email);
    }

    [GeneratedRegex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();

    public static implicit operator Email(string email) => new(email);
    public static implicit operator string(Email email) => email.Address;
}
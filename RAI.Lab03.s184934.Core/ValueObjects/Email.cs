using System.Text.RegularExpressions;
using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public partial record Email
{
    public string Address { get; }

    public Email(string address)
    {
        if (!IsValidEmail(address))
        {
            throw new InvalidValueException(typeof(Email), "Invalid email address");
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
}
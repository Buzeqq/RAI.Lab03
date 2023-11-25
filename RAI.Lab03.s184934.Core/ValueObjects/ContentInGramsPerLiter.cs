using System.Globalization;
using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record ContentInGramsPerLiter
{
    public const int MaxDecimals = 3;

    public ContentInGramsPerLiter(decimal content)
    {
        Content = content;
    }

    public ContentInGramsPerLiter(string content, IFormatProvider? cultureInfo = default)
    {
        if (decimal.TryParse(content, NumberStyles.Float, cultureInfo, out var result))
            Content = Math.Round(result, MaxDecimals);

        throw new InvalidFormatException(content);
    }

    public decimal Content { get; }

    public static implicit operator decimal(ContentInGramsPerLiter value)
    {
        return value.Content;
    }

    public static implicit operator ContentInGramsPerLiter(decimal value)
    {
        return new ContentInGramsPerLiter(value);
    }
}
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Core.Enums;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core;

public static class Extensions
{
    public static Mineralization CalculateMineralization(this IEnumerable<Ion> ion)
    {
        return ion.Sum(a => a.Content) switch
        {
            <= 0.05m => Mineralization.VeryLow,
            > 0.05m and <= 0.5m => Mineralization.Low,
            > 0.5m and <= 1.5m => Mineralization.Mid,
            > 1.5m => Mineralization.High
        };
    }
}
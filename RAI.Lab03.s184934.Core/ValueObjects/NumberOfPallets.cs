namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record NumberOfPallets
{
    public uint Value { get; }
    public const uint MaxValue = 200;
    
    public NumberOfPallets(uint value)
    {
        if (value > MaxValue)
        {
            throw new Exception("");
        }
        
        Value = value;
    }

    public static implicit operator NumberOfPallets(uint value) => new(value);
    public static implicit operator uint(NumberOfPallets pallets) => pallets.Value;
}
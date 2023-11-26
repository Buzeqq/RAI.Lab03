using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class WaterMagazine
{
    public Id WaterId { get; private set; }
    public uint Quantity { get; private set; }
    
    public WaterMagazine(Id waterId, uint quantity)
    {
        WaterId = waterId;
        Quantity = quantity;
    }
}
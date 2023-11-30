using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class SaleEntry
{
    public Id Id { get; private set; }
    public uint Quantity { get; private set; }
    
    public MineralWater Water { get; set; }

    public SaleEntry(Id id, uint quantity)
    {
        Id = id;
        Quantity = quantity;
    }
}
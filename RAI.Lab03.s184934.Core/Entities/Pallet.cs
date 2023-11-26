using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class Pallet
{
    public Id Id { get; init; }
    public uint SizeOfPallet { get; private set; }
    
    public MineralWater Water { get; private set; }

    public Pallet(Id id, uint sizeOfPallet)
    {
        Id = id;
        SizeOfPallet = sizeOfPallet;
    }
}
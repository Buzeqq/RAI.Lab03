using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class WaterType
{
    private WaterType()
    {
    }

    public WaterType(Id id, WaterTypeName name)
    {
        Id = id;
        Name = name;
    }

    public Id Id { get; private set; }
    public WaterTypeName Name { get; private set; }
}
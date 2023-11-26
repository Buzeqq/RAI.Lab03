using RAI.Lab03.s184934.Core.Enums;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class MineralWater
{
    public MineralWater(Id id, WaterName name, PhValue ph, string imagePath)
    {
        Id = id;
        Name = name;
        Ph = ph;
        ImagePath = imagePath;
    }

    public Id Id { get; private set; }
    public WaterName Name { get; private set; }
    public WaterType Type { get; set; }
    public Producer Producer { get; set; }
    public PhValue Ph { get; private set; }
    public ICollection<Cation> Cations { get; set; } = new List<Cation>();
    public ICollection<Anion> Anions { get; set; } = new List<Anion>();
    public Mineralization Mineralization => Cations.Concat<Ion>(Anions).CalculateMineralization();
    public Packaging Packaging { get; set; }
    public string ImagePath { get; private set; }
}
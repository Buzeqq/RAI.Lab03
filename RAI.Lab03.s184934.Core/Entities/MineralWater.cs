using RAI.Lab03.s184934.Core.Enums;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class MineralWater
{
    public Id Id { get; private set;  }
    public WaterName Name { get; private set; }
    public WaterType Type { get; private set; }
    public Producer Producer { get; private set; }
    public PhValue Ph { get; private set; }
    public ICollection<Cation> Cations { get; private set; } = new List<Cation>();
    public ICollection<Anion> Anions { get; private set; } = new List<Anion>();
    public Mineralization Mineralization => Cations.Concat<Ion>(Anions).CalculateMineralization();
    public Packaging Packaging { get; private set;  }
    public string ImagePath { get; private set;  }
}
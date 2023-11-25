using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public abstract class Ion
{
    protected Ion(Id id, IonName name, IonSymbol symbol, ContentInGramsPerLiter content)
    {
        Id = id;
        Name = name;
        Symbol = symbol;
        Content = content;
    }

    public Id Id { get; private set; }
    public IonName Name { get; private set; }
    public IonSymbol Symbol { get; private set; }
    public ContentInGramsPerLiter Content { get; private set; }
}

public sealed class Cation : Ion
{
    public Cation(Id id, IonName name, IonSymbol symbol, ContentInGramsPerLiter content) : base(id, name, symbol,
        content)
    {
    }
}

public sealed class Anion : Ion
{
    public Anion(Id id, IonName name, IonSymbol symbol, ContentInGramsPerLiter content) : base(id, name, symbol,
        content)
    {
    }
}
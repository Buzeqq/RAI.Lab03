using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record Id
{
    public Id(Guid value)
    {
        if (value == Guid.Empty) throw new EmptyIdException();

        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(Id id)
    {
        return id.Value;
    }

    public static implicit operator Id(Guid value)
    {
        return new Id(value);
    }
}
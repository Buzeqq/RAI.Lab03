using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.ValueObjects;

public sealed record Id
{
    public Guid Value { get; }

    public Id(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyIdException();
        }

        Value = value;
    }

    public static implicit operator Guid(Id id) => id.Value;
    public static implicit operator Id(Guid value) => new(value);
}
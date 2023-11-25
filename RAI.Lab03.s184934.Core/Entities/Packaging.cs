using RAI.Lab03.s184934.Core.Exceptions;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class Packaging
{
    public Packaging(Id id, string name, float volume)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new InvalidValueException(typeof(Packaging), name);

        if (volume < 0.0f) throw new InvalidVolumeException(volume);

        Id = id;
        Name = name;
        Volume = volume;
    }

    public Id Id { get; private set; }
    public string Name { get; private set; }
    public float Volume { get; private set; }
}
using RAI.Lab03.s184934.Core.Exceptions;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class Packaging
{
    public string Name { get; private set; }
    public float Volume { get; private set; }

    public Packaging(string name, float volume)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidValueException(typeof(Packaging), name);
        }

        if (volume < 0.0f)
        {
            throw new InvalidVolumeException(volume);
        }
        
        Name = name;
        Volume = volume;
    }
}
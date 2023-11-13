namespace RAI.Lab03.s184934.Core.Exceptions;

public sealed class InvalidVolumeException : WaterWarehouseException
{
    public InvalidVolumeException(float volume) : base($"Invalid volume value: {volume}. Must be grater than 0.0")
    {
    }
}
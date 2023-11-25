namespace RAI.Lab03.s184934.Web.Data.DTO.Packaging;

public sealed class PackagingDto
{
    public PackagingDto()
    {
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public float Volume { get; init; }

    public Core.Entities.Packaging AsPackaging(Guid id) => new(id, Name, Volume);
}
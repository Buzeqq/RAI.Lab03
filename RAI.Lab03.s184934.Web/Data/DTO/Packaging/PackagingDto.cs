using System.ComponentModel.DataAnnotations;

namespace RAI.Lab03.s184934.Web.Data.DTO.Packaging;

public sealed class PackagingDto
{ 
    public Guid Id { get; init; }
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Name { get; init; }
    [Required]
    [Range(0.1, 20.0)]
    public float Volume { get; init; }
    public string DisplayInformation => $"{Name}, {Volume}L";

    public PackagingDto()
    {
    }
    public Core.Entities.Packaging AsPackaging(Guid id) => new(id, Name, Volume);
}
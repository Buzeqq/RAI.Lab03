using System.ComponentModel.DataAnnotations;

namespace RAI.Lab03.s184934.Web.Data.DTO.WaterType;

public sealed class WaterTypeDto
{
    public WaterTypeDto()
    {
    }

    public WaterTypeDto(Guid Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

    [Required] public Guid Id { get; init; }

    [StringLength(20, MinimumLength = 3)] public string Name { get; init; }

    public Core.Entities.WaterType AsWaterType(Guid id) => new(id, Name);
}
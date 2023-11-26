using System.ComponentModel.DataAnnotations;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Web.Data.DTO.MineralWater;

public sealed class MineralWaterDto
{
    public Guid Id { get; init; }
    
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Name { get; init; }
    
    [Required]
    public Guid? Type { get; init; }
    
    [Required]
    public Guid? Producer { get; init; }
    
    [Required]
    [Range(0.0, 14.0)]
    public float Ph { get; init; } = PhValue.DefaultValue;

    public ICollection<Guid>? Cations { get; init; } = new List<Guid>();
    public ICollection<Guid>? Anions { get; init; } = new List<Guid>();
    public string Mineralization { get; init; } = "";
    [Required]
    public Guid? Packaging { get; init; }

    public string ImagePath { get; set; } = "";

    public MineralWaterDto()
    {
    }

    public Core.Entities.MineralWater AsMineralWater(Guid id) => new(id, Name, new PhValue(Ph), ImagePath);
}
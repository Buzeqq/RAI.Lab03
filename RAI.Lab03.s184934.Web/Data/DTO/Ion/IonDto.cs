using System.ComponentModel.DataAnnotations;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.DTO.Ion;

public sealed class IonDto
{
    public Guid Id { get; init; }

    [Required]
    [StringLength(20, MinimumLength = 3)] 
    public string Name { get; init; }

    [Required]
    [StringLength(10, MinimumLength = 2)]
    public string Symbol { get; init; }
    
    [Required]
    [DisplayFormat(DataFormatString = "{0:e}", ApplyFormatInEditMode = true)]
    public decimal Content { get; init; }
    
    [Required]
    public IonType Type { get; init; }

    public Core.Entities.Ion AsIon(Guid id)
    {
        return Type switch
        {
            IonType.Cation => new Cation(id, Name, Symbol, Content),
            IonType.Anion => new Anion(id, Name, Symbol, Content),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public string DisplayInformation => $"{Name}, {Symbol}, Content: {Content} g/l";
}
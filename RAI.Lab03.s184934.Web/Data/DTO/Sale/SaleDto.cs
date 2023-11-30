using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.DTO.Sale;

public class SaleDto
{
    public Guid Id { get; init; }
    public DateTime DateTime { get; init; } = DateTime.Now;
    public string Username { get; init; }
    public IEnumerable<SaleEntryDto> SaleEntries { get; set; } = new List<SaleEntryDto>();

    public uint SaleQuantity => (uint)SaleEntries.Sum(s => s.Quantity);
    
    public Core.Entities.Sale AsSale(Guid id)
    {
        return new Core.Entities.Sale(id, DateTime, Username);
    }
}

public class SaleEntryDto
{
    public uint Quantity { get; init; }
    public Guid WaterId { get; init; }
    
    public SaleEntry AsSaleEntry(Guid id)
    {
        return new SaleEntry(id, Quantity);
    }
}
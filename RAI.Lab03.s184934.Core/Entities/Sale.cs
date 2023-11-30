using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class Sale
{
    public Id Id { get; private set; }
    public DateTime Date { get; private set; }
    public string UserName { get; private set; }

    
    public ICollection<SaleEntry> SaleEntries { get; set; } = new List<SaleEntry>();

    public Sale(Id id, DateTime date, string userName)
    {
        Id = id;
        Date = date;
        UserName = userName;
    }
}
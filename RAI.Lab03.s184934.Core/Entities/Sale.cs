using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class Sale
{
    public Id Id { get; private set; }
    public uint Quantity { get; private set; }
    public DateTime Date { get; private set; }
    
    public string UserName { get; private set; }

    public Sale(Id id, uint quantity, DateTime date)
    {
        Id = id;
        Quantity = quantity;
        Date = date;
    }
}
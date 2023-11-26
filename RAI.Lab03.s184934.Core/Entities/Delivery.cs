using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Core.Entities;

public sealed class Delivery
{
    public Id Id { get; private set; }
    public NumberOfPallets NumberOfPallets { get; init; }
    public DateTime Date { get; private set; }
    public string User { get; private set; }


    public ICollection<Pallet> Pallets { get; private set; } = new List<Pallet>();
    public Supplier Supplier { get; private set; }

    public Delivery(Id id, NumberOfPallets numberOfPallets, DateTime date, string user)
    {
        Id = id;
        NumberOfPallets = numberOfPallets;
        Date = date;
        User = user;
    }
}
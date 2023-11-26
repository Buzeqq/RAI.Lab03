namespace RAI.Lab03.s184934.Web.Data.DTO.Delivery;

public sealed class DeliveryDto
{
    public Guid Id { get; init; }
    public uint NumberOfPallets { get; init; } = 0;
    public DateTime Date { get; init; } = DateTime.Now;
    public string User { get; init; }
    public Guid Supplier { get; init; }
    public ICollection<Guid> Pallets { get; set; } = new List<Guid>();

    public Core.Entities.Delivery AsDelivery(Guid id) => new(id, NumberOfPallets, Date, User);
}
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data.DTO.Delivery;

public sealed class PalletDto
{
    public Guid Id { get; init; }
    public Guid WaterId { get; init; }
    public uint PalletSize { get; init; }

    public Pallet AsPallet(Guid id) => new(id, PalletSize);
}
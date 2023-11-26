using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.Delivery;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;
using RAI.Lab03.s184934.Web.Data.DTO.Packaging;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Data;

public static class Extensions
{
    public static CompanyType GetCompanyType(this Company company) =>
        company switch
        {
            Producer => CompanyType.Producer,
            Supplier => CompanyType.Supplier,
            _ => throw new ArgumentOutOfRangeException(nameof(company))
        };

    public static IonDto AsDto(this Ion ion) =>
        new()
        {
            Id = ion.Id,
            Name = ion.Name,
            Symbol = ion.Symbol,
            Content = ion.Content,
            Type = ion.GetIonType()
        };

    public static IonType GetIonType(this Ion ion) =>
        ion switch
        {
            Cation => IonType.Cation,
            Anion => IonType.Anion,
            _ => throw new ArgumentOutOfRangeException(nameof(ion))
        };

    public static WaterTypeDto AsDto(this WaterType type) =>
        new()
        {
            Id = type.Id,
            Name = type.Name
        };

    public static CompanyDto AsDto(this Company company) =>
        new()
        {
            Id = company.Id,
            Name = company.Name,
            Email = company.Email,
            PhoneNumber = company.PhoneNumber,
            Type = company.GetCompanyType()
        };

    public static PackagingDto AsDto(this Packaging packaging) =>
        new()
        {
            Id = packaging.Id,
            Name = packaging.Name,
            Volume = packaging.Volume
        };

    public static MineralWaterDto AsDto(this MineralWater mineralWater) =>
        new()
        {
            Id = mineralWater.Id,
            Anions = mineralWater.Anions.Select(a => a.Id.Value).ToList(),
            Cations = mineralWater.Cations.Select(c => c.Id.Value).ToList(),
            ImagePath = mineralWater.ImagePath,
            Mineralization = mineralWater.Mineralization.ToString(),
            Name = mineralWater.Name,
            Packaging = mineralWater.Packaging.Id,
            Ph = mineralWater.Ph.Value,
            Producer = mineralWater.Producer.Id,
            Type = mineralWater.Type.Id
        };

    public static DeliveryDto AsDto(this Delivery delivery) =>
        new()
        {
            Id = delivery.Id,
            NumberOfPallets = delivery.NumberOfPallets,
            Date = delivery.Date,
            Supplier = delivery.Supplier.Id,
            Pallets = delivery.Pallets.Select(p => p.Id.Value).ToList(),
            User = delivery.User
        };

    public static PalletDto AsDto(this Pallet pallet) =>
        new()
        {
            Id = pallet.Id,
            PalletSize = pallet.SizeOfPallet,
            WaterId = pallet.Water.Id
        };
}
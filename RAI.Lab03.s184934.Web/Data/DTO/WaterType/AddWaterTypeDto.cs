namespace RAI.Lab03.s184934.Web.Data.DTO.WaterType;

public sealed record AddWaterTypeDto(string Name);

public sealed record UpdateWaterTypeDto(Guid Id, string Name);

public sealed record DeleteWaterTypeDto(Guid Id, string Name);

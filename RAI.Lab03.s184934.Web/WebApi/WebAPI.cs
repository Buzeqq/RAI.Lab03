using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Sale;

namespace RAI.Lab03.s184934.Web.WebApi;

public static class WebApi
{
    public static void UseWebApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/water/types", async (WarehouseDbContext dbContext) =>
        {
            var waterTypes = await dbContext.WaterTypes
                .Select(w => w.AsDto()).ToListAsync();

            return Results.Ok(waterTypes);
        });

        app.MapGet("api/users", async (UsersDbContext dbContext) =>
        {
            var users = await dbContext.Users
                .Select(u => u.AsDto())
                .ToListAsync();

            return Results.Ok(users);
        });
        
        app.MapGet("api/waters", async (WarehouseDbContext dbContext) =>
        {
            var waters = await dbContext.MineralWaters
                .Include(w => w.Packaging)
                .Include(w => w.Anions)
                .Include(w => w.Cations)
                .Include(w => w.Type)
                .Include(w => w.Producer)
                .Select(w => w.AsDto())
                .ToListAsync();

            return Results.Ok(waters);
        });

        app.MapMethods("api/sales", 
            new[] { "POST", "PUT" }, 
            async ([FromBody] SaleDto dto, WarehouseDbContext dbContext) =>
            {
                var sale = dto.AsSale(Guid.NewGuid());

                foreach (var entryDto in dto.SaleEntries)
                {
                    var mineralWater = await dbContext.MineralWaters.FindAsync(new Id(entryDto.WaterId));

                    if (mineralWater is null) return Results.NotFound("Water not found!");
                    var saleEntry = entryDto.AsSaleEntry(Guid.NewGuid());
                    saleEntry.Water = mineralWater;
                    
                    sale.SaleEntries.Add(saleEntry);
                }
                    
                await dbContext.Sales.AddAsync(sale);
                await dbContext.SaveChangesAsync();
                
                return Results.Ok();
            });
    }
}
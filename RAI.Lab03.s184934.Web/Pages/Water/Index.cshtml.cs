using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;
using RAI.Lab03.s184934.Web.Data.DTO.Packaging;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Pages.Water;

public class IndexModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public IndexModel(WarehouseDbContext context)
    {
        _context = context;
    }

    public IList<MineralWaterDto> MineralWaterDtos { get;set; } = default!;
    public IEnumerable<CompanyDto> Producers;
    public IEnumerable<PackagingDto> Packaging;
    public IEnumerable<WaterTypeDto> Types;

    public async Task OnGetAsync()
    {
        var mineralWaters = await _context.MineralWaters
            .Include(w => w.Packaging)
            .Include(w => w.Anions)
            .Include(w => w.Cations)
            .Include(w => w.Producer)
            .Include(w => w.Type)
            .ToListAsync();

        MineralWaterDtos = mineralWaters.Select(m => m.AsDto()).ToList();
        Producers = mineralWaters.Select(w => w.Producer.AsDto()).DistinctBy(p => p.Id);
        Packaging = mineralWaters.Select(w => w.Packaging.AsDto()).DistinctBy(p => p.Id);
        Types = mineralWaters.Select(w => w.Type.AsDto()).DistinctBy(t => t.Id);
    }
}
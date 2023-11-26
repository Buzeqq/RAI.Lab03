using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;
using RAI.Lab03.s184934.Web.Data.DTO.Packaging;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Pages.Water;

public class DetailsModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public DetailsModel(WarehouseDbContext context)
    {
        _context = context;
    }

    public MineralWaterDto MineralWaterDto { get; set; } = default!;
    public CompanyDto ProducerDto { get; set; }
    public WaterTypeDto WaterTypeDto { get; set; }
    public PackagingDto PackagingDto { get; set; }
    public IEnumerable<IonDto> AnionDtos { get; set; }
    public IEnumerable<IonDto> CationDtos { get; set; }

public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var mineralWater = await _context.MineralWaters
            .Include(w => w.Producer)
            .Include(w => w.Packaging)
            .Include(w => w.Anions)
            .Include(w => w.Cations)
            .Include(w => w.Type)
            .SingleOrDefaultAsync(m => m.Id == new Id(id));
        if (mineralWater is null)
        {
            return NotFound();
        }
        
        MineralWaterDto = mineralWater.AsDto();
        ProducerDto = mineralWater.Producer.AsDto();
        WaterTypeDto = mineralWater.Type.AsDto();
        PackagingDto = mineralWater.Packaging.AsDto();
        CationDtos = mineralWater.Cations.Select(c => c.AsDto()).ToList();
        AnionDtos = mineralWater.Anions.Select(a => a.AsDto()).ToList();
        return Page();
    }
}
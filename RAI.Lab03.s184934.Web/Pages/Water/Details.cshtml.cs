using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;

namespace RAI.Lab03.s184934.Web.Pages.Water;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public MineralWaterDto MineralWaterDto { get; set; } = default!; 

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var mineralWater = await _context.MineralWaters.FirstOrDefaultAsync(m => m.Id == new Id(id));
        if (mineralWater is null)
        {
            return NotFound();
        }

        MineralWaterDto = mineralWater.AsDto();
        return Page();
    }
}
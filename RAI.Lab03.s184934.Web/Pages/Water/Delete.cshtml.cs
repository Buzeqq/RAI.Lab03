using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.MineralWater;

namespace RAI.Lab03.s184934.Web.Pages.Water;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MineralWaterDto MineralWater { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var mineralWater = await _context.MineralWaters
            .Include(w => w.Producer)
            .Include(w => w.Anions)
            .Include(w => w.Cations)
            .Include(w => w.Packaging)
            .Include(w => w.Type)
            .SingleOrDefaultAsync(m => m.Id == new Id(id));

        if (mineralWater is null)
        {
            return NotFound();
        }

        MineralWater = mineralWater.AsDto();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }
        var mineralWater = await _context.MineralWaters.FindAsync(new Id(id));

        if (mineralWater == null) return RedirectToPage("./Index");
        _context.MineralWaters.Remove(mineralWater);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
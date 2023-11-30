using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Pages.Water.Type;

public class DeleteModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public DeleteModel(WarehouseDbContext context)
    {
        _context = context;
    }

    [BindProperty] public WaterTypeDto WaterType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty) return NotFound();

        var waterType = await _context.WaterTypes.FirstOrDefaultAsync(m => m.Id == new Id(id));

        if (waterType is null) return NotFound();

        WaterType = new WaterTypeDto(waterType.Id, waterType.Name);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        if (id == Guid.Empty) return NotFound();
        var waterType = await _context.WaterTypes.FindAsync(new Id(id));

        if (waterType is null) return RedirectToPage("./Index");

        _context.WaterTypes.Remove(waterType);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
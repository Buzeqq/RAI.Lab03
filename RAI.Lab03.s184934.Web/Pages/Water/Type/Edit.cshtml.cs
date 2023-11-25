using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Pages.Water.Type;

internal class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public UpdateWaterTypeDto WaterType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty || _context.WaterTypes == null)
        {
            return NotFound();
        }

        var watertype = await _context.WaterTypes.FirstOrDefaultAsync(m => m.Id == (Id)id);
        if (watertype == null)
        {
            return NotFound();
        }
        WaterType = new UpdateWaterTypeDto(watertype.Id, watertype.Name);
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var waterType = new WaterType(WaterType.Id, WaterType.Name);
        _context.Attach(waterType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WaterTypeExists(WaterType.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool WaterTypeExists(Guid id)
    {
        return (_context.WaterTypes?.Any(e => e.Id == (Id)id)).GetValueOrDefault();
    }
}

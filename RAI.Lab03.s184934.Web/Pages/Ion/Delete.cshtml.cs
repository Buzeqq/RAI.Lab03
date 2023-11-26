using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;

namespace RAI.Lab03.s184934.Web.Pages.Ion;

public class DeleteModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public DeleteModel(WarehouseDbContext context)
    {
        _context = context;
    }

    [BindProperty] public IonDto IonDto { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty) return NotFound();

        var ion = await _context.Ion.FirstOrDefaultAsync(m => m.Id == new Id(id));

        if (ion is null) return NotFound();

        IonDto = ion.AsDto();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        if (id == Guid.Empty) return NotFound();
        var ion = await _context.Ion.FindAsync(new Id(id));

        if (ion is null) return RedirectToPage("./Index");

        _context.Ion.Remove(ion);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
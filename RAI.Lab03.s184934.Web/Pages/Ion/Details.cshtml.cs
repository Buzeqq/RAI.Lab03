using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;

namespace RAI.Lab03.s184934.Web.Pages.Ion;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IonDto Ion { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty) return NotFound();

        var ion = await _context.Ion.FirstOrDefaultAsync(m => m.Id == new Id(id));
        if (ion is null) return NotFound();

        Ion = ion.AsDto();
        return Page();
    }
}
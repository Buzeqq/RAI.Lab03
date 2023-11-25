using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;

namespace RAI.Lab03.s184934.Web.Pages.Ion;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(IonDto.AsIon(IonDto.Id)).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IonExists(IonDto.Id)) return NotFound();

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool IonExists(Id id)
    {
        return (_context.Ion?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
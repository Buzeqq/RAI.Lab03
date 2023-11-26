using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;

namespace RAI.Lab03.s184934.Web.Pages.Ion;

public class CreateModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public CreateModel(WarehouseDbContext context)
    {
        _context = context;
    }

    [BindProperty] public IonDto Ion { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Ion.Add(Ion.AsIon(Guid.NewGuid()));
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
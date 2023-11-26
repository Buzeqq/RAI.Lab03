using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Packaging;

namespace RAI.Lab03.s184934.Web.Pages.Packaging;

public class CreateModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public CreateModel(WarehouseDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public PackagingDto PackagingDto { get; set; } = default!;
        

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Packaging.Add(PackagingDto.AsPackaging(Guid.NewGuid()));
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
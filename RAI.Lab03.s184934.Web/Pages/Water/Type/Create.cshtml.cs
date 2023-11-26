using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Pages.Water.Type;

internal class CreateModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public CreateModel(WarehouseDbContext context)
    {
        _context = context;
    }

    [BindProperty] public WaterTypeDto WaterType { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var waterType = new WaterType(Guid.NewGuid(), WaterType.Name);

        _context.WaterTypes.Add(waterType);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
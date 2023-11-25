using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Pages.Water.Type;

internal class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public AddWaterTypeDto WaterType { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || _context.WaterTypes == null || WaterType == null)
        {
            return Page();
        }

        var waterType = new WaterType(Guid.NewGuid(), WaterType.Name);

        _context.WaterTypes.Add(waterType);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

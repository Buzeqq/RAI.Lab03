using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;

namespace RAI.Lab03.s184934.Web.Pages.Companies;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public CompanyDto CompanyDto { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        Company? company;
        try
        {
            company = CompanyDto.AsCompany(Guid.NewGuid());
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return Page();
        }

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
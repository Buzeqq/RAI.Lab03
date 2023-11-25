using System.ComponentModel.DataAnnotations;
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

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public AddCompanyDto CompanyDto { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Company? company;
        try
        {
            company = CompanyDto.AsCompany();
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

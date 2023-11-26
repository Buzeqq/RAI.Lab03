using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;

namespace RAI.Lab03.s184934.Web.Pages.Company;

public class DetailsModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public DetailsModel(WarehouseDbContext context)
    {
        _context = context;
    }

    public CompanyDto CompanyDto { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty) return NotFound();

        var company = await _context.Companies
            .FirstOrDefaultAsync(m => m.Id == new Id(id));

        if (company is null) return NotFound();

        CompanyDto = company.AsDto();
        return Page();
    }
}
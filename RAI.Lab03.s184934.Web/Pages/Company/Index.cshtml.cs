using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;

namespace RAI.Lab03.s184934.Web.Pages.Company;

public class IndexModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public IndexModel(WarehouseDbContext context)
    {
        _context = context;
    }

    public IList<CompanyDto> CompanyDtos { get; set; } = default!;

    public async Task OnGetAsync()
    {
        CompanyDtos = await _context.Companies.Select(c => c.AsDto()).ToListAsync();
    }
}
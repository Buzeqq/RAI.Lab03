using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Web.Data;

namespace RAI.Lab03.s184934.Web.Pages.Companies;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Company> Companies { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Companies != null)
        {
            Companies = await _context.Companies.ToListAsync();
        }
    }
}

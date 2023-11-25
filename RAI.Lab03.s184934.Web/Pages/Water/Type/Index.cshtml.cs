using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Web.Data;

namespace RAI.Lab03.s184934.Web.Pages.Water.Type;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<WaterType> WaterType { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.WaterTypes != null) WaterType = await _context.WaterTypes.ToListAsync();
    }
}
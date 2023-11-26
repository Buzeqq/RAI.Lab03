using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Packaging;

namespace RAI.Lab03.s184934.Web.Pages.Packaging;

public class IndexModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public IndexModel(WarehouseDbContext context)
    {
        _context = context;
    }

    public IList<PackagingDto> PackagingDtos { get;set; } = default!;

    public async Task OnGetAsync()
    {
        PackagingDtos = await _context.Packaging.Select(p => p.AsDto()).ToListAsync();
    }
}
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Sale;

namespace RAI.Lab03.s184934.Web.Pages.Sale;

public class IndexModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public IndexModel(WarehouseDbContext context)
    {
        _context = context;
    }

    public IList<SaleDto> SaleDtos { get;set; } = default!;

    public async Task OnGetAsync()
    {
        SaleDtos = await _context.Sales
            .Include(s => s.SaleEntries)
            .ThenInclude(e => e.Water)
            .Select(p => p.AsDto())
            .ToListAsync();
    }
}
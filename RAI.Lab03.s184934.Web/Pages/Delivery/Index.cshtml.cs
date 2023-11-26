using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Company;
using RAI.Lab03.s184934.Web.Data.DTO.Delivery;

namespace RAI.Lab03.s184934.Web.Pages.Delivery;

public class IndexModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public IndexModel(WarehouseDbContext context)
    {
        _context = context;
    }

    public IList<DeliveryDto> Delivery { get;set; } = default!;
    public IEnumerable<CompanyDto> AvailableSuppliers { get; set; }

    public async Task OnGetAsync()
    {
        AvailableSuppliers = await _context.Supplier
            .AsNoTracking()
            .Select(s => s.AsDto())
            .ToListAsync();
        
        Delivery = await _context.Deliveries
            .AsNoTracking()
            .Include(d => d.Pallets)
            .Include(d => d.Supplier)
            .Select(d => d.AsDto())
            .ToListAsync();
    }
}
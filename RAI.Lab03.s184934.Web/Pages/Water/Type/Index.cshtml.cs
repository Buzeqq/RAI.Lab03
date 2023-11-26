using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.WaterType;

namespace RAI.Lab03.s184934.Web.Pages.Water.Type;

public class IndexModel : PageModel
{
    private readonly WarehouseDbContext _context;

    public IndexModel(WarehouseDbContext context)
    {
        _context = context;
    }

    public IList<WaterTypeDto> WaterTypeDtos { get; set; } = default!;

    public async Task OnGetAsync()
    {
        WaterTypeDtos = await _context.WaterTypes.Select(t => t.AsDto()).ToListAsync();
    }
}
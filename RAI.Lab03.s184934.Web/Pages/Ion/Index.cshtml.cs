using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Ion;

namespace RAI.Lab03.s184934.Web.Pages.Ion;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<IonDto> Ion { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Ion = await _context.Ion.Select(i => i.AsDto()).ToListAsync();
    }
}
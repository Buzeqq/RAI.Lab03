using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Data;

namespace RAI.Lab03.s184934.Web.Pages.Ion
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Core.Entities.Ion> Ion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ion != null)
            {
                Ion = await _context.Ion.ToListAsync();
            }
        }
    }
}

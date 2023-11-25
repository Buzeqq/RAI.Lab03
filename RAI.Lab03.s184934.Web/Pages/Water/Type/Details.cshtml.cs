using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.Entities;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;

namespace RAI.Lab03.s184934.Web.Pages.Water.Type
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public WaterType WaterType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty || _context.WaterTypes == null)
            {
                return NotFound();
            }

            var watertype = await _context.WaterTypes.FirstOrDefaultAsync(m => m.Id == (Id)id);
            if (watertype == null)
            {
                return NotFound();
            }
            else
            {
                WaterType = watertype;
            }
            return Page();
        }
    }
}

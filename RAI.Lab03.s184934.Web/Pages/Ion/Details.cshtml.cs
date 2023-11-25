using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Web.Pages.Ion
{
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DetailsModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Core.Entities.Ion Ion { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Id id)
        {
            if (id == null || _context.Ion == null)
            {
                return NotFound();
            }

            var ion = await _context.Ion.FirstOrDefaultAsync(m => m.Id == id);
            if (ion == null)
            {
                return NotFound();
            }

            Ion = ion;
            return Page();
        }
    }
}

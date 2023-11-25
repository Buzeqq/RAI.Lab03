using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Data.DTO.Packaging;

namespace RAI.Lab03.s184934.Web.Pages.Packaging
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public PackagingDto PackagingDto { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var packaging = await _context.Packaging.FirstOrDefaultAsync(m => m.Id == new Id(id));
            if (packaging is null)
            {
                return NotFound();
            }

            PackagingDto = packaging.AsDto();
            return Page();
        }
    }
}

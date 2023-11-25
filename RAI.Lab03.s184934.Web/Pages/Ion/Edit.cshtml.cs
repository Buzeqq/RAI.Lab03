using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.ValueObjects;

namespace RAI.Lab03.s184934.Web.Pages.Ion
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public EditModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Core.Entities.Ion Ion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var ion =  await _context.Ion.FirstOrDefaultAsync(m => m.Id == new Id(id));
            if (ion is null)
            {
                return NotFound();
            }
            Ion = ion;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IonExists(Ion.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool IonExists(Id id)
        {
          return (_context.Ion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
